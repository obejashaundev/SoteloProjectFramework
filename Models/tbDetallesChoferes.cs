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
    
    public partial class tbDetallesChoferes
    {
        public int DetalleChoferId { get; set; }
        public int ChoferId { get; set; }
        public string Unidad { get; set; }
        public string PlacasUnidad { get; set; }
        public string DescripcionUnidad { get; set; }
        public int Edad { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string FechaNacimientoStr { get; set; }
        public string LicenciaConducir { get; set; }
        public string NSS { get; set; }
    
        public virtual tbChoferes tbChoferes { get; set; }
    }
}
