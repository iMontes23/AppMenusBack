using log4net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Navistar.Business.Core.Security;
using Navistar.Utils.Core;
using Navistar.Web.API.Providers;
using System;
using System.Threading.Tasks;

namespace Navistar.Web.API.Controllers.Security
{
    [Produces(Constants.CONFIG_PRODUCES)]
    [Route(UrlConstants.API_ROUTE_SECURITY)]
    public class UserAccessController : Controller
    {
        private readonly ISecurity profile;
        private readonly IUserAccessBusiness _userAccessBusiness;
        private ILog _log;

        public UserAccessController(ISecurity security, IUserAccessBusiness userAccessBusiness)
        {
            this.profile = security;
            this._userAccessBusiness = userAccessBusiness;
            _log = new Navistar.Utils.Logger.Logger().GetLog();
        }


        [EnableCors(Constants.CONFIG_CORS_POLICY)]
        [HttpGet(UrlConstants.GET_USER_INFORMATION)]
        public async Task<IActionResult> GetUserInformationIntranet([FromQuery] string userAuth)
        {
            try
            {
                _log.Info("Obtener menu de la aplicación por usuario");
                var accessList = await this._userAccessBusiness.GetUserInformation(userAuth);
                _log.Info("Usuario obtenido " + accessList?.Name);
                return Ok(accessList);
            }
            catch (UnauthorizedAccessException exception)
            {
                _log.Error("Error al obtener el usuario.");
                _log.Error(exception.StackTrace);
                return Unauthorized();
            }
        }

        [EnableCors(Constants.CONFIG_CORS_POLICY)]
        [HttpGet(UrlConstants.GET_USER_INFORMATION_INTRANET)]
        public async Task<IActionResult> GetUserInformation()
        {
            try
            {
                _log.Info("Obtener menu de la aplicación por usuario por intranet.");
                IServerVariablesFeature serverVars = HttpContext.Features.Get<IServerVariablesFeature>();
                profile.SetCredentials(serverVars);
                string userID = profile.GetUser();

                var accessList = await this._userAccessBusiness.GetUserInformation(userID);
                _log.Error("Usuario obtenido "+ accessList?.Name);
                return Ok(accessList);
            }
            catch (UnauthorizedAccessException exception)
            {
                _log.Error("Error al obtener el usuario en intranet.");
                _log.Error(exception.StackTrace);
                return Unauthorized();
            }
        }


        [EnableCors(Constants.CONFIG_CORS_POLICY)]
        [HttpGet(UrlConstants.GET_USER_MENU)]
        public async Task<IActionResult> GetUserMenuItems([FromQuery] string userID)
        {
            try
            {
                _log.Error("Obtener menu de la aplicación por usuario");
                if (userID == null || userID == "")
                {
                    IServerVariablesFeature serverVars = HttpContext.Features.Get<IServerVariablesFeature>();
                    profile.SetCredentials(serverVars);
                    userID = profile.GetUser();
                }
                
                var accessList = await this._userAccessBusiness.GetUserMenuItems(userID);
                _log.Error("Número de menu obtenido: "+ accessList.Count);
                return Ok(accessList);
            }
            catch (UnauthorizedAccessException exception)
            {
                _log.Error("Error al obtener el menu.");
                _log.Error(exception.StackTrace);
                return Unauthorized();
            }
        }

    }
}
