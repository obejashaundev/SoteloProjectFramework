using System;
using System.Collections.Generic;
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
}