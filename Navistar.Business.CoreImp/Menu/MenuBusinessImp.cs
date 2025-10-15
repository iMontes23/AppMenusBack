using log4net;
using Navistar.Business.Core.Menus;
using Navistar.Business.Core.Security;
using Navistar.Model.common.DTO.Menu;
using Navistar.Model.common.DTO.Security;
using Navistar.Model.common.Excepciones;
using Navistar.Repository.Carga.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Navistar.Business.CoreImp.Menu
{
    public class MenuBusinessImp : IMenuBusiness
    {
        private IMenuRepository _menuRepository;
        private readonly IUserAccessBusiness _userAccessBusiness;
        private readonly ILog _log;
        private string _CLASE = "MenuBusinessImp";

        public MenuBusinessImp(ILog log, IMenuRepository menuRepository, IUserAccessBusiness userAccessBusiness) { 
            _log = log;
            _menuRepository = menuRepository;
            _userAccessBusiness = userAccessBusiness;
        }

        public async Task<List<UserApplicationDTO>> GetMenus(string userID)
        {
            try
            {
                var listaApps = (await GetMenuApps()).Where(a => a.Activo).ToList();
               
                var tasks = listaApps.Select(async app =>
                {
                    _log.Info($"[{_CLASE}::GetMenus] -> Procesando aplicación: {app.CodigoApp} - {app.NombreMenu}");
                    var items = await _userAccessBusiness.GetUserMenuItems(userID, app.CodigoApp);
                    _log.Info($"[{_CLASE}::GetMenus] -> Aplicación {app.CodigoApp}: {items.Count} menús obtenidos.");
                    return items;
                });

                var results = await Task.WhenAll(tasks);
                var listaMenus = results.SelectMany(r => r).Where(i => i.MenuItems.Any()).ToList();
                _log.Info($"[{_CLASE}::GetMenus] -> Total de menús obtenidos: {listaMenus.Count}.");

                return listaMenus;
            }
            catch (AppException)
            {
                throw;
            }
            catch(Exception ex)
            {
                _log.Error($"[{_CLASE}::GetMenus] -> Error al consultar las aplicaciones activas: {ex.Message}", ex);
                throw new AppException(1, "Error al consultar los menus de las aplicacines");
            }
        }

        public async Task<IEnumerable<MenuAppItemDTO>> GetEstructuraMenusApp(string userID)
        {
            try
            {
                _log.Info($"{_CLASE}:::GetEstructuraMenusApp -> Cargando aplicaciones activas...");
                var appsLocal = await _menuRepository.GetEstructuraMenusApp();
                var menusRaiz = GeneraEstructura(appsLocal);
                //var tasks = menus.Select(m => ConsultaMenusGuardian(m ,userID));
                //await Task.WhenAll(tasks);
                foreach (var menu in menusRaiz)
                    await ConsultaMenusGuardian(menu, userID);

                // se eliminana los menus que no tiene permiso en guardian.
                var menusFiltrados =
                    menusRaiz.Select(Filter).Where(i => i != null).ToList();


                _log.Info($"{_CLASE}:::GetEstructuraMenusApp -> Se encontraron {appsLocal.Count()} aplicaciones activas.");

                return menusFiltrados;
            }
            catch (Exception ex)
            {
                _log.Error($"{_CLASE}:::GetEstructuraMenusApp -> Error al consultar las aplicaciones activas: {ex.Message}", ex);
                throw new AppException(1, "Error al consultar las aplicaciones activas");
            }
        }


        private MenuAppItemDTO Filter(MenuAppItemDTO menu)
        {
            if (menu == null)
                return null;

            if (!string.IsNullOrEmpty(menu.Url) && (menu.Items == null || !menu.Items.Any()))
                return menu;

            menu.Items = menu.Items?
                .Select(Filter)
                .Where(m => m != null)
                .ToList();

            return (menu.Items != null && menu.Items.Any()) ? menu : null;
        }


        private async Task ConsultaMenusGuardian(MenuAppItemDTO app, string userID)
        {
            try
            {
                if(app.EsApp && !string.IsNullOrEmpty(app.Codigo))
                {
                    _log.Info($"[{_CLASE}::GetMenus] -> Procesando aplicación: {app.Codigo} - {app.Nombre}");
                    var items = await _userAccessBusiness.GetUserMenuItems(userID, app.Codigo);
                    _log.Info($"[{_CLASE}::GetMenus] -> Aplicación {app.Codigo}: {items.Count} menús obtenidos.");

                    app.Nombre = items.First().Application;
                    app.Items = ConvierteItemMenu(items.First().MenuItems);
                
                }else if(!app.EsApp && app.Items.Any())
                {
                    foreach (var item in app.Items)
                        await ConsultaMenusGuardian(item, userID);
                }
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _log.Error($"[{_CLASE}::GetMenus] -> Error al consultar las aplicaciones activas: {ex.Message}", ex);
                throw new AppException(1, "Error al consultar los menus de las aplicacines");
            }

        }

        public List<MenuAppItemDTO> ConvierteItemMenu(List<MenuItemDTO> mItems)
        {
            var m = new List<MenuAppItemDTO>(); 
            foreach (MenuItemDTO item in mItems)
            {
                var itemDTO = new MenuAppItemDTO
                {
                    Nombre = item.Name,
                    Codigo = item.AppCode,
                    Descripcion = item.DescripcionOpcion,
                    Objetivo = item.Objetivo,
                    Category = item.Category,
                    nombreMenu = item.nombreMenu,
                    nombreModulo = item.nombreModulo,
                    EsApp = (item.Items == null || item.Items.Count == 0),
                    Url = item.Url
                };

                if(item.Items != null && item.Items.Any())
                    itemDTO.Items = ConvierteItemMenu(item.Items);

                m.Add(itemDTO);
            }

            return m;
        }
       

        private IEnumerable<MenuAppItemDTO> GeneraEstructura(IEnumerable<MenuAppItemDTO> menusApps)
        {
            var lookup = menusApps.ToDictionary(m => m.Id);
            var raiz = new List<MenuAppItemDTO>();
            foreach (var item in menusApps)
            {
                if (item.ParentId == null)
                {
                    raiz.Add(item);
                }
                else if (lookup.ContainsKey(item.ParentId.Value))
                {
                    lookup[item.ParentId.Value].Items.Add(item);
                }
            }
            return raiz;
        }

        public async Task<IEnumerable<MenuAppDTO>> GetMenuApps()
        {
            try
            {
                _log.Info($"{_CLASE}:::GetMenuApps -> Cargando aplicaciones activas...");
                var aplicaciones = await _menuRepository.GetMenuApps();
                _log.Info($"{_CLASE}:::GetMenuApps -> Se encontraron {aplicaciones.Count()} aplicaciones activas.");
                
                return aplicaciones;
            }catch (Exception ex) {
                _log.Error($"{_CLASE}:::GetMenuApps -> Error al consultar las aplicaciones activas: {ex.Message}", ex);
                throw new AppException(1 ,"Error al consultar las aplicaciones activas");
            }
        }
        


    }
}
