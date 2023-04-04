using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoteloProjectFramework.Servicios
{
    public class SesionesActivas : FilterAttribute, IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            //Obtenemos el listado de las propiedades de la clase Sessiones y despues verificamos que ninguna sessión este nula. De lo contrario mandamos a login.

            var lsSesiones = (from r in new Sesiones().GetType().GetProperties()
                              select new
                              {
                                  valor = HttpContext.Current.Session[r.Name]
                              });

            if (lsSesiones.Where(a => a.valor == null).Any())
            {
                FuncionalidadesGenerales fg = new FuncionalidadesGenerales();

                //Tratamos de recuperar las sesiones antes de que al usuario se le mande a Login
                if (!fg.RecuperarSesiones())
                {
                    filterContext.Result = new RedirectResult("/Account/Login");
                    HttpContext.Current.Session["UrlTmp"] = HttpContext.Current.Request.RawUrl;
                    return;
                }
            }
        }
    }

    public static class ObtenerSesiones
    {
        public static string NombreUsuarioLogueado
        {
            get
            {
                Sesiones sc = new Sesiones();
                return string.IsNullOrEmpty(sc.NombreUsuarioLogueado) ? string.Empty : sc.NombreUsuarioLogueado;
            }
        }
        public static string NombreCompletoUsuarioLogueado
        {
            get
            {
                Sesiones sc = new Sesiones();
                return string.IsNullOrEmpty(sc.NombreCompletoUsuarioLogueado) ? string.Empty : sc.NombreCompletoUsuarioLogueado;
            }
        }
    }

}