using System.Collections.Generic;

namespace Navistar.Model.common.DTO.Security
{
    public class MenuItemDTO
    {
        public string AppCode { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string UrlTarget { get; set; }
        public List<MenuItemDTO> Items { get; set; } = new List<MenuItemDTO>();

    }
}
