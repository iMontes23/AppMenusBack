using Navistar.Model.common.DTO.Menu;
using Navistar.Model.common.DTO.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Navistar.Business.Core.Menus
{
    public interface IMenuBusiness
    {
        Task<IEnumerable<MenuAppDTO>> GetMenuApps();
        Task<List<UserApplicationDTO>> GetMenus(string userID);
        Task<IEnumerable<MenuAppItemDTO>> GetEstructuraMenusApp(string userID);
    }
}
