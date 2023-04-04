using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoteloProjectFramework.Models;

namespace SoteloProjectFramework.Servicios
{
    public class RecursosGenerales
    {
        public void CargarSesiones()
        {
            try
            {
                using (var db = new EntidadesSotelo())
                {
                    var oRecursos = db.cRecursosGenerales.ToList();

                    foreach (var oRecurso in oRecursos)
                    {
                        HttpContext.Current.Session[oRecurso.Descripcion] = oRecurso.Valor;
                    }
                }
            }
            catch (Exception ex)
            {
                var oError = ex.Message;
            }
        }

        public string ClaveMaster
        {
            get
            {
                var oDescripcion = "ClaveMaster";
                var oValor = "";

                if (HttpContext.Current.Session[oDescripcion] == null)
                {
                    using (var db = new EntidadesSotelo())
                    {
                        HttpContext.Current.Session[oDescripcion] = db.cRecursosGenerales.Where(a => a.Descripcion == oDescripcion).FirstOrDefault().Valor;
                    }
                }

                oValor = (string)HttpContext.Current.Session[oDescripcion];

                return oValor;
            }
        }

        public string RolMaster
        {
            get
            {
                var oDescripcion = "RolMaster";
                var oValor = "";

                if (HttpContext.Current.Session[oDescripcion] == null)
                {
                    using (var db = new EntidadesSotelo())
                    {
                        HttpContext.Current.Session[oDescripcion] = db.cRecursosGenerales.Where(a => a.Descripcion == oDescripcion).FirstOrDefault().Valor;
                    }
                }

                oValor = (string)HttpContext.Current.Session[oDescripcion];

                return oValor;
            }
        }

        public string RolAdministradores
        {
            get
            {
                var oDescripcion = "RolAdministradores";
                var oValor = "";

                if (HttpContext.Current.Session[oDescripcion] == null)
                {
                    using (var db = new EntidadesSotelo())
                    {
                        HttpContext.Current.Session[oDescripcion] = db.cRecursosGenerales.Where(a => a.Descripcion == oDescripcion).FirstOrDefault().Valor;
                    }
                }

                oValor = (string)HttpContext.Current.Session[oDescripcion];

                return oValor;
            }
        }

    }
}