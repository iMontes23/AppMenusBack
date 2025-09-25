using Dapper;
using log4net;
using Navistar.Database.Carga.Query;
using Navistar.Database.Carga.Query.Security;
using Navistar.DataContext;
using Navistar.Model.common.DTO.Security;
using Navistar.Model.common.Excepciones;
using Navistar.Repository.Carga.Security;
using Navistar.Utils.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Navistar.Repository.CargaImp.Security
{
    public class UserAccessRepository : IUserAccessRepository
    {

        private DBDatamartImp _dbConnection;
        private ILog _log;
        private string _CLASE = "UserAccessRepository";

        public UserAccessRepository(ILog log, DBDatamartImp dbConnection)
        {
            _dbConnection = dbConnection;
            _log = log;
        }

        public async Task<UserInformationDTO> GetUserInformation(string userID)
        {
            try
            {
               
                var parameters = new DynamicParameters();
                parameters.Add(ArgumentsNamesDB.USER_ID, userID, DbType.String, ParameterDirection.Input);

                string storedProcedure = SpNamesDB.GET_USER_INFORMATION;
                _log.Info("Obtener conexión");
                using var _dbContext = this._dbConnection.CrearConexion();
                await _dbContext.OpenAsync();

                _log.Info("########### Ejecución de SPS GET_USER_INFORMATION #####");
                IEnumerable<UserInformationDTO> result = await _dbContext.QueryAsync<UserInformationDTO>(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                _log.Info("Resultado "+ result.Count());

                return result.Count() > 0 ? result.First() : null;

            }
            catch (Exception exception)
            {
                _log.Error(exception.StackTrace);
                throw;
            }
        }
        public async Task<IEnumerable<UserApplicationDTO>> GetUserMenuItems(string userID)
        {
            try
            {
                string appCode = this._dbConnection.getAppCode();
                var parameters = new DynamicParameters();
                parameters.Add(ArgumentsNamesDB.NTUSER, userID, DbType.String, ParameterDirection.Input);
                parameters.Add(ArgumentsNamesDB.APP_CODE, string.IsNullOrWhiteSpace(appCode) ? Constants.EMPTY_STRING : appCode.Trim(),
                    DbType.String, ParameterDirection.Input);

                var parameters2 = new DynamicParameters();
                parameters2.Add(ArgumentsNamesDB.APP_CODE, string.IsNullOrWhiteSpace(appCode) ? Constants.EMPTY_STRING : appCode.Trim(),
                    DbType.String, ParameterDirection.Input);

                string storedProcedureAplication = SpNamesDB.GET_USER_APLICATION;
                string storedProcedurePermission = SpNamesDB.GET_USER_PERMISSIONS;

                using var _dbContext = this._dbConnection.CrearConexion();
                await _dbContext.OpenAsync();

                _log.Info("########### Ejecución de SP SGET_USER_APLICATION #####");

                IEnumerable<UserMenuOptionDTO> result = await _dbContext.QueryAsync<UserMenuOptionDTO>(
                        storedProcedurePermission,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                _log.Info("########### Ejecución de SP GET_USER_APLICATION #####");
                IEnumerable<UserApplicationDTO> result2 = await _dbContext.QueryAsync<UserApplicationDTO>(
                        storedProcedureAplication,
                        parameters2,
                        commandType: CommandType.StoredProcedure
                 );

                if (result2 != null)
                {
                    result2.First().Type = "MENU";
                    result2.First().HasOptions = true;
                }

                MapMenuData(result2, result);

                return result2;
            }
            catch (Exception exception)
            {
                _log.Error("Error al permisos");
                _log.Error(exception.StackTrace);
                throw;
            }
        }

        private IEnumerable<UserApplicationDTO> MapMenuData(
            IEnumerable<UserApplicationDTO> applicationsUser, IEnumerable<UserMenuOptionDTO> optionsMenuUser)
        {
            try
            {
                _log.Info("Create a dictionary to group options by AppCode");
                Dictionary<string, List<UserMenuOptionDTO>> optionsByApp = new Dictionary<string, List<UserMenuOptionDTO>>();

                _log.Info("Group options by AppCode");
                foreach (var option in optionsMenuUser)
                {
                    if (!optionsByApp.ContainsKey(option.AppCode))
                    {
                        optionsByApp[option.AppCode] = new List<UserMenuOptionDTO>();
                    }
                    optionsByApp[option.AppCode].Add(option);
                }

                // Assign options to the corresponding menus
                _log.Info("Assign options to the corresponding menus");
                foreach (var application in applicationsUser)
                {
                    if (optionsByApp.TryGetValue(application.AppCode, out var opcionesParaMenu))
                    {
                        application.ApplicationOptions = opcionesParaMenu;
                    }
                    else
                    {
                        application.ApplicationOptions = new List<UserMenuOptionDTO>();
                    }
                }
                _log.Info("result applicationsUser");
                return applicationsUser;

            }
            catch (Exception exception)
            {
                _log.Error("Error al mapear datos");
                _log.Error(exception.StackTrace);
                throw exception;
            }
        }

        public async Task<IEnumerable<UserInformationDTO>> GetUser(Boolean status)
        {
            try
            {
                _log.Info("Obtener conexión");
                using var _dbContext = this._dbConnection.CrearConexion();
                await _dbContext.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add(ArgumentsNamesDB.IS_ACTIVE, status, DbType.Boolean, ParameterDirection.Input);
                _log.Info("Ejecución de SPS de SPS_GET_USER_BY_STACTIVO");

                string storedProcedure = SpNamesDB.SPS_GET_USER_BY_STACTIVO;

                IEnumerable<UserInformationDTO> result = await _dbContext.QueryAsync<UserInformationDTO>(
                    storedProcedure,
                parameters,
                    commandType: CommandType.StoredProcedure
                );

                _log.Info("Resultado de Sp");
                return result;

            }
            catch (Exception exception)
            {
                _log.Error("Error al obtener el grupos");
                _log.Error(exception.Message);
                throw;
            } 
        }

        public async Task<IEnumerable<UserApplicationDTO>> GetUserMenuItems(string userID, string appCode)
        {
            try
            {
                IEnumerable<UserApplicationDTO> aplicaciones = await GetUserApplication(appCode);
                IEnumerable<UserMenuOptionDTO> menus = await GetUserMenus(userID, appCode);

                if (aplicaciones != null && aplicaciones.Any())
                {
                    var app = aplicaciones.First();
                    app.Type = "MENU";
                    app.HasOptions = true;

                    MapMenuData(aplicaciones, menus);
                }
                else
                {
                    _log.Warn($"[{_CLASE}::[GetUserMenuItems] -> No se encontraron aplicaciones para userID={userID}, appCode={appCode}");
                    return Enumerable.Empty<UserApplicationDTO>();
                }

                return aplicaciones;
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _log.Error($"[{_CLASE}::GetUserMenuItems] -> Error al consultar permisos para userID={userID}, appCode={appCode}");
                _log.Error($"[{_CLASE}::GetUserMenuItems] -> Error al consultar las aplicaciones activas: {ex.Message}", ex);
                throw new AppException(1, "Error al consultar los menus de las aplicacines");
            }
        }

        private async Task<IEnumerable<UserApplicationDTO>> GetUserApplication(string appCode)
        {
            try
            {
                var parametros = new DynamicParameters();
                parametros.Add(ArgumentsNamesDB.APP_CODE, appCode,
                    DbType.String, ParameterDirection.Input);

                using var _dbContext = this._dbConnection.CrearConexion();
                await _dbContext.OpenAsync();

                _log.Info($"[{_CLASE}:::GetUserApplication] -> Ejecutando: {SpNamesDB.GET_APP} @AppCode = {appCode}...");
                IEnumerable<UserApplicationDTO> aplicaciones = await _dbContext.QueryAsync<UserApplicationDTO>(
                        SpNamesDB.GET_APP,
                        parametros,
                        commandType: CommandType.StoredProcedure
                 );
                return aplicaciones;
            }
            catch (Exception ex)
            {
                _log.Error($"[{_CLASE}:::GetUserApplication] -> Error al consultar la informacion de la aplicación {appCode}: {ex.Message}", ex);
                throw new AppException(1, "No se puedo consultar la información de las aplicaciones");
            }
        }

        private async Task<IEnumerable<UserMenuOptionDTO>> GetUserMenus(string userID, string appCode)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(ArgumentsNamesDB.USER_ID, userID, DbType.String, ParameterDirection.Input);
                parameters.Add(ArgumentsNamesDB.APP_CODE, string.IsNullOrWhiteSpace(appCode) ? Constants.EMPTY_STRING : appCode.Trim(),
                    DbType.String, ParameterDirection.Input);

                using var _dbContext = this._dbConnection.CrearConexion();
                await _dbContext.OpenAsync();

                _log.Info($"[{_CLASE}:::GetUserApplication] -> Ejecutando: {SpNamesDB.SP_MENU_Y_MODULOS_POR_USUARIO}" +
                    $"@UserID = {userID} @AppCode = {appCode}...");
                IEnumerable<UserMenuOptionDTO> menus = await _dbContext.QueryAsync<UserMenuOptionDTO>(
                        SpNamesDB.SP_MENU_Y_MODULOS_POR_USUARIO,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );
                
                return menus;
            }
            catch (Exception ex)
            {
                _log.Error($"[{_CLASE}:::GetUserApplication] -> Error al consultar los menus de la aplicación {appCode}: {ex.Message}", ex);
                throw new AppException(1, "No se puedo consultar los menus de las aplicaciones");
            }
        }
    }
}
