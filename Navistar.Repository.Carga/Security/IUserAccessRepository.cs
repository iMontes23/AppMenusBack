using Navistar.Model.common.DTO.Security;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Navistar.Repository.Carga.Security
{
    public interface IUserAccessRepository
    {
        Task<UserInformationDTO> GetUserInformation(string userID);

        Task<IEnumerable<UserApplicationDTO>> GetUserMenuItems(string userID);
        Task<IEnumerable<UserApplicationDTO>> GetUserMenuItems(string userID, string appCode);

        Task<IEnumerable<UserInformationDTO>> GetUser(Boolean status);

    }
}
