//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoteloProjectFramework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbMenusRoles
    {
        public int ConfiguracionId { get; set; }
        public int MenuId { get; set; }
        public int UsuarioId { get; set; }
        public bool Estatus { get; set; }
    
        public virtual cMenus cMenus { get; set; }
        public virtual tbUsuarios tbUsuarios { get; set; }
    }
}