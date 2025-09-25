using log4net;
using Microsoft.AspNetCore.Mvc;
using Navistar.Business.Core.Security;
using Navistar.Utils.Core;
using Navistar.Web.API.Providers;
using System;
using System.Threading.Tasks;

namespace Navistar.Web.API.Controllers.Security
{
    [Produces(Constants.CONFIG_PRODUCES)]
    [Route(UrlConstants.API_ROUTE_USER)]
    public class UserController : Controller
    {
        private readonly ISecurity profile;
        private readonly IUserAccessBusiness _userAccessBusiness;
        private ILog _log;

        public UserController(ISecurity security, IUserAccessBusiness userAccessBusiness)
        {
            this.profile = security;
            this._userAccessBusiness = userAccessBusiness;
            _log = new Navistar.Utils.Logger.Logger().GetLog();
        }



        [HttpGet(UrlConstants.GET_USERS)]
        public async Task<IActionResult> GetUsers([FromQuery] Boolean status)
        {
            try
            {
                _log.Info("Se inició la obtención de usuarios");
                var accessList = await this._userAccessBusiness.GetUser(status);
                _log.Info("Se Finalizó la obtención de usuarios");
                return Ok(accessList);
            }
            catch (UnauthorizedAccessException exception)
            {
                _log.Error(exception.StackTrace);
                return Unauthorized();
            }
        }

    }
}
