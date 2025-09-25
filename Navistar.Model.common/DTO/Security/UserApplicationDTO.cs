using System.Collections.Generic;

namespace Navistar.Model.common.DTO.Security
{
    public class UserApplicationDTO
    {

        public string AppCode { get; set; }

        public string Type { get; set; }

        public string URLTarget { get; set; }

        public string URL { get; set; }

        public string Application { get; set; }

        public string Server { get; set; }

        public bool HasOptions { get; set; }

        public string CdTAM { get; set; }

        public string Color { get; set; }

        public string Icon { get; set; }

        public string Image { get; set; }

        public string PresentationType { get; set; }

        public string Initials { get; set; }

        public List<UserMenuOptionDTO> ApplicationOptions { get; set; } // For DB

        public List<MenuItemDTO> MenuItems { get; set; } // For Frontend

    }
}
