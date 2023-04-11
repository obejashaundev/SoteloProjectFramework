using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoteloProjectFramework.Models;
using static SoteloProjectFramework.Models.ModelosGenerales;

namespace SoteloProjectFramework.Servicios
{
    public class FuncionalidadesGenerales
    {
        public bool RecuperarSesiones()
        {
            using (EntidadesSotelo db = new EntidadesSotelo())
            {
                try
                {
                    RecursosGenerales rg = new RecursosGenerales();

                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        var oNombreUsuario = HttpContext.Current.User.Identity.Name;
                        var oUsuario = db.tbUsuarios.FirstOrDefault(a => a.UserName == oNombreUsuario);

                        AsignarSesionesInicioSesion(oNombreUsuario);

                        //Asignamos los Accesos
                        ObtenerDatosAccesoUsuario(oUsuario.UsuarioId);

                    }
                }
                catch
                {
                    return false;
                }

                var lsSesiones = (from r in new Sesiones().GetType().GetProperties()
                                  select new
                                  {
                                      valor = HttpContext.Current.Session[r.Name]
                                  });

                if (lsSesiones.Where(a => a.valor == null).Any())
                    return false;

                return true;
            }

        }

        internal string NombreCompletoUsuario(tbUsuarios tbUsuarios)
        {
            var oNombreCompleto = string.Empty;
            try
            {
                if (tbUsuarios == null)
                    return "";

                oNombreCompleto = string.Format("{0} - {1} {2} {3}"
                    , (string.IsNullOrEmpty(tbUsuarios.UserName) ? "" : tbUsuarios.UserName)
                    , (string.IsNullOrEmpty(tbUsuarios.PrimerApellido) ? "" : tbUsuarios.PrimerApellido)
                    , (string.IsNullOrEmpty(tbUsuarios.SegundoApellido) ? "" : tbUsuarios.SegundoApellido)
                    , (string.IsNullOrEmpty(tbUsuarios.Nombres) ? "" : tbUsuarios.Nombres)
                    );
            }
            catch (Exception)
            {
                oNombreCompleto = "Reporta este registro con tu ejecutivo de cuenta.";
            }

            return oNombreCompleto;
        }

        public void AsignarSesionesInicioSesion(string pUsuario)
        {
            var sc = new Sesiones();
            using (EntidadesSotelo db = new EntidadesSotelo())
            {
                var oUsuario = db.tbUsuarios.FirstOrDefault(a => a.UserName == pUsuario);

                //Asignamos el plantel a la sesión
                sc.RolUsuarioLogueado = (oUsuario == null) ? "0" : (string.IsNullOrEmpty(oUsuario.RolId) ? "" : oUsuario.RolId);
                sc.NombreUsuarioLogueado = (oUsuario == null) ? "" : (string.IsNullOrEmpty(oUsuario.Nombres) ? "" : oUsuario.Nombres);
                sc.NombreCompletoUsuarioLogueado = (oUsuario == null) ? "" : (string.IsNullOrEmpty(oUsuario.Nombres) ? "" : $"{oUsuario.Nombres} {oUsuario.PrimerApellido} {oUsuario.SegundoApellido}");
                sc.CorreoUsuarioLogueado = (oUsuario == null) ? "" : (string.IsNullOrEmpty(oUsuario.Email) ? "" : oUsuario.Email);
                sc.UsuarioId = oUsuario.UsuarioId;
            }
        }

        public ListaAccesosDenegados ObtenerDatosAccesoUsuario(int pUsuarioId)
        {
            try
            {
                #region Validación de usuarios logueados

                Sesiones sc = new Sesiones();
                RecursosGenerales rg = new RecursosGenerales();
                var oUsuarioAnterior = 0;
                var oUsuarioNuevo = pUsuarioId;

                if (HttpContext.Current.Session["UsuarioLogueado"] == null)
                {
                    HttpContext.Current.Session["UsuarioLogueado"] = pUsuarioId;
                }
                else
                {
                    oUsuarioAnterior = (int)HttpContext.Current.Session["UsuarioLogueado"];
                }

                if (oUsuarioNuevo != oUsuarioAnterior)
                {
                    HttpContext.Current.Session["UsuarioLogueado"] = pUsuarioId;
                    HttpContext.Current.Session["MenuCSS"] = null;
                    HttpContext.Current.Session["MenuSlug"] = null;
                }

                using (EntidadesSotelo db = new EntidadesSotelo())
                {

                    var badGuyIds = db.tbMenusRoles.Where(a => a.UsuarioId == pUsuarioId && !a.Estatus).Select(a => a.MenuId).ToArray();
                    var oDtosAcceso = db.cMenus.Where(p => badGuyIds.Contains(p.MenuId)).Select(a => a.CSS).ToArray();
                    HttpContext.Current.Session["MenuCSS"] = oDtosAcceso.ToList();
                }



                ////slug
                //if (HttpContext.Current.Session["MenuSlug"] == null)
                //{
                //    using (EntidadesSotelo db = new EntidadesSotelo())
                //    {
                //        var oDtosAcceso = db.tbMenusRoles.Where(a => a.UsuarioId == pUsuarioId && a.cMenus.Estatus == true && a.Estatus == true).Select(a => a.cMenus.Slug + "|" + a.cMenus.RolId).ToList();

                //        HttpContext.Current.Session["MenuSlug"] = oDtosAcceso;
                //    }
                //}
                ////slug

                #endregion

                var lsCssExtraidos = (from r in (List<string>)HttpContext.Current.Session["MenuCSS"]
                                      select new
                                      {
                                          CSS = r.ToString()

                                      });


                var lsCSS = lsCssExtraidos.Select(a => a.CSS).ToList();
                //slug
                var lsSlug = (List<string>)HttpContext.Current.Session["MenuSlug"];
                //slug
                return new ListaAccesosDenegados(lsCSS, lsSlug);
            }
            catch (Exception)
            {
            }

            return new ListaAccesosDenegados(new List<string>(), new List<string>());
        }
    }
}