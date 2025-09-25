using Navistar.Model.common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Navistar.Utils.Core
{
    public class FilterUtility
    {
        private string FilterFront { get; }
        private IList<string> Filters { get; } = new List<string>();

        public FilterUtility(string filterFront)
        {
            try
            {
                filterFront = StringUtility.LimpiarFiltroPermitirCaracteres(filterFront);
                this.FilterFront = filterFront;
                if (!string.IsNullOrEmpty(this.FilterFront))
                {
                    Filters = this.FilterFront.Split(Constante.SEPARADOR);
                }
            }
            catch (Exception)
            {
                Filters = new List<string>();
            }
        }

        public String ObtenerFiltro(int indice)
        {
            try
            {
                if (Filters.Count > 0 && (Filters.Count - 1) >= indice)
                {
                    return Filters.ElementAt(indice);
                }
                return String.Empty;
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

    }
}
