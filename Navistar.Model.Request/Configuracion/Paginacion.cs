using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Model.Request.Configuracion
{
    public class Paginacion
    {
        public int page { get; set; }
        public int size { get; set; }
        public string sort { get; set; }
        public string dir
        {
            get; set; 
            //get { return this.dir.ToUpper(); }

            //set { this.dir = value; }
        }

    }
}
