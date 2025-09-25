using Dapper;
using log4net;
using Navistar.Database.Carga.Query.Security;
using Navistar.DataContext;
using Navistar.Model.common.DTO.Menu;
using Navistar.Repository.Carga.Menu;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navistar.Repository.CargaImp.Menu
{
    public class MenuRepositoryImp : IMenuRepository
    {
        private DBDatamartImp _dbContextImp;
        private ILog _log;
        private string _CLASE = "MenuRepositoryImp";
        public MenuRepositoryImp(ILog iLog,DBDatamartImp dbContextImp)
        {
            _dbContextImp = dbContextImp;
            _log = iLog;
        }

        

        public async Task<IEnumerable<MenuAppDTO>> GetMenuApps()
        {
            using (var conn = _dbContextImp?.GetConexion())
            {
                await conn.OpenAsync().ConfigureAwait(false);

               var parametros = new DynamicParameters();
                parametros.Add("@accion", 0, DbType.Int64, ParameterDirection.Input);

                _log.Info($"{_CLASE}:::GetMenuApps -> Ejecutando: {SpNamesDB.GET_MENUS_APPS} @accion = {0}...");

                var menusApps = await conn.QueryAsync<MenuAppDTO>(
                  SpNamesDB.GET_MENUS_APPS,
                  parametros,
                  commandType: CommandType.StoredProcedure
              );

                return menusApps;
            }
        }
        public async Task<IEnumerable<MenuAppItemDTO>> GetEstructuraMenusApp()
        {
            using (var conn = _dbContextImp?.GetConexion())
            {
                await conn.OpenAsync().ConfigureAwait(false);
                _log.Info($"{_CLASE}:::GetEstructuraMenusApp -> Ejecutando: {SpNamesDB.GET_ARBOL_MENUS_APPS}");

                var menusApps = await conn.QueryAsync<MenuAppItemDTO>(
                  SpNamesDB.GET_ARBOL_MENUS_APPS,
                  commandType: CommandType.StoredProcedure
              );
                
                return menusApps;
            }
        }

    }
}
