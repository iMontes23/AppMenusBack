using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Model.common.DTO
{
    public class PermisoDTO
    {
        public Int64? IdTrasladista { get; set; }
        public String UserID { get; set; } 
        public String UserName { get; set; } 
        public String UserRole { get; set; }
        public String Email { get; set; }
        public String Module { get; set; }
        public String Function { get; set; }
        public bool Permit { get; set; }
    }
}
