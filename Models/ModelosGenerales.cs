using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SoteloProjectFramework.Models
{
    public class ModelosGenerales
    {
        public class ListaAccesosDenegados : Tuple<List<string>, List<string>>
        {
            public ListaAccesosDenegados(List<string> lsCSS, List<string> lsSlug)
                : base(lsCSS, lsSlug)
            {

            }

            public List<string> CSS { get { return this.Item1; } }
            public List<string> Slug { get { return this.Item2; } }

        }
    }

    public class AjaxResponse
    {
        private bool _Success = false;
        private string _Message = String.Empty;
        private dynamic _Data { get; set; }

        public bool Success { get { return _Success; } set { _Success = value; } }
        public string Message { get { return _Message; } set { _Message = value; } }
        public dynamic Data { get { return _Data; } set { _Data = value; } }
    }


    public class ModeloExtendidoChofer
    {
        public tbChoferes Chofer { get; set; }
        public tbDetallesChoferes DetalleChofer { get; set; }
    }

    public class ModeloExtendidoViaje
    {
        public tbViajes Viajes { get; set; }
        public tbChoferes Chofer { get; set; }
        public tbContabilidadViaje Contabilidad { get; set; }
    }

    public class ModeloExtendidoBuzon
    {
        public IEnumerable<tbBuzon> Buzones { get; set; }
        public tbBuzon Buzon { get; set; }
    }
}