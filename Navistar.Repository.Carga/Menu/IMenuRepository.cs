using Navistar.Model.common.DTO.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Navistar.Repository.Carga.Menu
{
    public interface IMenuRepository
    {
        Task<IEnumerable<MenuAppDTO>> GetMenuApps();
        Task<IEnumerable<MenuAppItemDTO>> GetEstructuraMenusApp();
    }
}
