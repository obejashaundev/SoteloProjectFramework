using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoteloProjectFramework.Servicios
{
    public class Sesiones
    {
        public string RolUsuarioLogueado
        {
            get
            {
                var oValor = (string)HttpContext.Current.Session["RolUsuarioLogueado"];
                return oValor;
            }
            set
            {
                HttpContext.Current.Session["RolUsuarioLogueado"] = value.ToString();
            }
        }
        public string NombreUsuarioLogueado
        {
            get
            {
                var oValor = (string)HttpContext.Current.Session["NombreUsuarioLogueado"];
                return oValor;
            }
            set
            {
                HttpContext.Current.Session["NombreUsuarioLogueado"] = value.ToString();
            }
        }
        public string NombreCompletoUsuarioLogueado
        {
            get
            {
                var oValor = (string)HttpContext.Current.Session["NombreCompletoUsuarioLogueado"];
                return oValor;
            }
            set
            {
                HttpContext.Current.Session["NombreCompletoUsuarioLogueado"] = value.ToString();
            }
        }
        public string CorreoUsuarioLogueado
        {
            get
            {
                var oValor = (string)HttpContext.Current.Session["CorreoUsuarioLogueado"];
                return oValor;
            }
            set
            {
                HttpContext.Current.Session["CorreoUsuarioLogueado"] = value.ToString();
            }
        }
        public int UsuarioId
        {
            get
            {
                var oValor = (string)HttpContext.Current.Session["UsuarioId"];
                if (oValor == null)
                    return 0;
                return int.Parse(oValor);
            }
            set
            {
                HttpContext.Current.Session["UsuarioId"] = value.ToString();
            }
        }
    }
}