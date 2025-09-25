using Navistar.Model.common.DTO.Security;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Navistar.Business.Core.Security
{
    public interface IUserAccessBusiness
    {
        Task<UserInformationDTO> GetUserInformation(string userID);

        Task<List<UserApplicationDTO>> GetUserMenuItems(string userID);
        
        Task<List<UserApplicationDTO>> GetUserMenuItems(string userID,string appCode);

        Task<IEnumerable<UserInformationDTO>> GetUser(Boolean status);

    }
}
