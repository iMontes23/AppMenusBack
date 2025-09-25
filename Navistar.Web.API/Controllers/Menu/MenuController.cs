using Microsoft.AspNetCore.Mvc;
using Navistar.Utils.Core;
using System.Threading.Tasks;
using System;
using log4net;
using Navistar.Business.Core.Menus;
using System.Linq;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Navistar.Model.common.Excepciones;

namespace Navistar.Web.API.Controllers.Menu
{
    [Produces(Constants.CONFIG_PRODUCES)]
    [Route(UrlConstants.API_ROUTE_MENUS)]
    public class MenuController : Controller
    {

        private readonly ILog _log;
        private IMenuBusiness _menuBusiness;
        private string _CLASE = "MenuController";

        public MenuController(ILog log, IMenuBusiness menuBusiness)
        {
            _log = log;
            _menuBusiness = menuBusiness;
        }


        [HttpGet(UrlConstants.GET_MENU_APPS)]
        public async Task<IActionResult> ConsultaMenusApplicaciones(string userID)
        {
            try
            {
                _log.Info($"[{_CLASE}:::ConsultaMenusApplicaciones] -> Iniciando carga de menús...");
                var listaMenus = await _menuBusiness.GetMenus(userID);
                _log.Info($"[{_CLASE}:::ConsultaMenusApplicaciones] -> Fin carga de menús...");
                return Ok(listaMenus);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _log.Error($"[{_CLASE}:::ConsultaMenusApplicaciones] -> Error al obtener los menus del usuario.", ex);
                return StatusCode(500, "Ocurrió un error al procesar los menus del usuario.");
            }
        }


        [HttpGet(UrlConstants.GET_ESTRUCTURA_MENU_APPS)]
        public async Task<IActionResult> ConsultaEstructuraMenus(string userID)
        {
            try
            {
                _log.Info($"[{_CLASE}:::ConsultaMenusApplicaciones] -> Iniciando carga de menús...");
                var listaMenus = await _menuBusiness.GetEstructuraMenusApp(userID);
                _log.Info($"[{_CLASE}:::ConsultaMenusApplicaciones] -> Fin carga de menús...");
                return Ok(listaMenus);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _log.Error($"[{_CLASE}:::ConsultaMenusApplicaciones] -> Error al obtener los menus del usuario.", ex);
                return StatusCode(500, "Ocurrió un error al procesar los menus del usuario.");
            }
        }
    }
}
