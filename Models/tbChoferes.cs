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
    
    public partial class tbChoferes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbChoferes()
        {
            this.tbDetallesChoferes = new HashSet<tbDetallesChoferes>();
            this.tbViajes = new HashSet<tbViajes>();
        }
    
        public int ChoferId { get; set; }
        public int CategoriaChoferId { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public byte[] Imagen { get; set; }
        public bool Estatus { get; set; }
        public bool Eliminado { get; set; }
        public string FechaElimino { get; set; }
    
        public virtual tbCategoriasChoferes tbCategoriasChoferes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbDetallesChoferes> tbDetallesChoferes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbViajes> tbViajes { get; set; }
    }
}