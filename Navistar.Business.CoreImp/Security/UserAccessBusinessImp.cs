using log4net;
using Navistar.Business.Core.Security;
using Navistar.Model.common.DTO.Security;
using Navistar.Repository.Carga.Security;
using Navistar.Utils.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navistar.Business.CoreImp.Security
{
    public class UserAccessBusinessImp : IUserAccessBusiness
    {
        private readonly IUserAccessRepository _userAccessRepository;
        private ILog _log;

        public UserAccessBusinessImp(IUserAccessRepository userAccessRepository)
        {
            this._userAccessRepository = userAccessRepository;
            _log = new Navistar.Utils.Logger.Logger().GetLog();
        }

        public async Task<UserInformationDTO> GetUserInformation(string userID)
        {
            UserInformationDTO userInformation = await _userAccessRepository.GetUserInformation(userID);

            if (userInformation == null)
            {
                _log.Error(MessagesConstants.USER_NOT_FOUND);
                throw new UnauthorizedAccessException(MessagesConstants.USER_NOT_FOUND);
            }

            return userInformation;
        }

        public async Task<List<UserApplicationDTO>> GetUserMenuItems(string userID)
        {
            IEnumerable<UserApplicationDTO> menuItems = await _userAccessRepository.GetUserMenuItems(userID);
            if (!menuItems.Any())
            {
                _log.Error(MessagesConstants.NO_ACCESS_PERMISSIONS_FOUND);
                throw new UnauthorizedAccessException(MessagesConstants.NO_ACCESS_PERMISSIONS_FOUND);
            }

            return BuildMenuHierarchy(menuItems);
        }

        public List<UserApplicationDTO> BuildMenuHierarchy(IEnumerable<UserApplicationDTO> menuApplications)
        {
            List<UserApplicationDTO> result = new List<UserApplicationDTO>();

            foreach (var application in menuApplications)
            {
                var parent = new MenuItemDTO();
                foreach (var item in application.ApplicationOptions)
                {
                    var levelsArray = item.Category
                        .Replace(Constants.MENU_PREFIX, Constants.EMPTY_STRING)
                        .Replace(Constants.MAPA_DETVIN_PREFIX, Constants.INPUT_VIN_CODE) // For input VIN
                        .Replace(Constants.MAPA_DETVINWR_PREFIX, Constants.INPUT_VIN_CODE) // For input VIN
                        .Replace(Constants.MAPA_PREFIX, Constants.EMPTY_STRING)
                        .Split(Constants.NUMBER_SIGN);

                    AddMenuItem(parent, levelsArray, 0, item);
                }

                application.Initials = NameInitialsExtractor.GetInitials(application.Application);
                application.ApplicationOptions = null;
                application.MenuItems = parent.Items;                
                result.Add(application);
            }

            return result;
        }

        static void AddMenuItem(MenuItemDTO parent, string[] levels, int levelIndex, UserMenuOptionDTO item)
        {
            if (levels.Length > 0 && levels[0] == Constants.REPO_PREFIX)
            {
                var repoItem = new MenuItemDTO
                {
                    AppCode = item.AppCode,
                    Name = item.ModuleDesc,
                    Url = item.URL,
                    UrlTarget = item.URLTarget,
                    DescripcionOpcion = item.DescripcionOpcion,
                    Objetivo = item.Objetivo,
                    Category = item.Category,
                    nombreMenu = item.nombreMenu,
                    nombreModulo = item.nombreModulo,
                    Items = null
                };

                if (!parent.Items.Any(i => i.AppCode == repoItem.AppCode && i.Name == repoItem.Name) )
                {
                    parent.Items.Add(repoItem);
                }
                return;
            }

            if (levelIndex >= levels.Length) return;

            var levelName = levels[levelIndex];
            var existingItem = parent.Items.FirstOrDefault(item => item.AppCode == levelName);

            if (existingItem == null)
            {
                bool isOption = levelIndex + 1 == levels.Length; // (levelIndex + 1) -> Current index

                string name = isOption
                    ? item.ModuleDesc
                    : levelName; // Submenu

                existingItem = new MenuItemDTO()
                {
                    AppCode = levelName,
                    Name = name,
                    Url = isOption ? item.URL : null,
                    UrlTarget = isOption ? item.URLTarget : null,
                    DescripcionOpcion = isOption ? item.DescripcionOpcion : null,
                    Objetivo = isOption ? item.Objetivo : null,
                    Category = item.Category,
                    nombreMenu = item.nombreMenu,
                    nombreModulo = item.nombreModulo,
                    Items = isOption ? null : new List<MenuItemDTO>()
                };
                parent.Items.Add(existingItem);
            }

            AddMenuItem(existingItem, levels, levelIndex + 1, item);
        }

        public async Task<IEnumerable<UserInformationDTO>> GetUser(bool st_Activo)
        {
            var groupList = await _userAccessRepository.GetUser(st_Activo)
                ?? throw new KeyNotFoundException(MessagesConstants.NO_RECORD_FOUND);

            return groupList;
        }

        public async Task<List<UserApplicationDTO>> GetUserMenuItems(string userID, string appCode)
        {
            IEnumerable<UserApplicationDTO> menuItems = await _userAccessRepository.GetUserMenuItems(userID, appCode);
            if (!menuItems.Any())
            {
                return new List<UserApplicationDTO>();
            }
            return BuildMenuHierarchy(menuItems);
        }
    }
}
