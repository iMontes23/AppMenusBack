using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Model.common.DTO.Menu
{
    public class MenuAppItemDTO
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Objetivo { get; set; }
        public string Category { get; set; }
        public string nombreMenu { get; set; }
        public string nombreModulo { get; set; }
        public int? Orden { get; set; }
        public bool Activo { get; set; }
        public bool EsApp { get; set; }
        public string Url { get; set; }
        public List<MenuAppItemDTO> Items { get; set; } = new List<MenuAppItemDTO>();
    }
}
