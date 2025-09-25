using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using Mastercon;
using System;
using log4net;

namespace Navistar.DataContext
{
    public class DBDatamartImp
    {
        private Masterconnect_Interface _dbConnectionString;
        private readonly IOptions<ConnectionsConfig> _connectionsConfig;
        private ILog _log;

        // Variable estática para almacenar la cadena de conexión (Singleton)
        private static string _cachedConnectionString;

        // Atributo para garantizar el acceso seguro a la variable
        private static readonly object _lock = new object();

        public DBDatamartImp(IOptions<ConnectionsConfig> connectionsConfig)
        {
            _dbConnectionString = new Masterconnect();
            _connectionsConfig = connectionsConfig;
            _log = new Navistar.Utils.Logger.Logger().GetLog();
        }

        public string getAppCode()
        {
            return _connectionsConfig.Value.APP_CODE;
        }

        public SqlConnection CrearConexion()
        {
            try
            {
                _log.Info("Intenta obtener la cadena de conexión.");
                string connectionString = GetCachedConnectionString();
                
                _log.Info("Crear la conexión a la base de datos usando la cadena almacenada.");
                var connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                // Si falla la conexión, actualiza la cadena de conexión
                _log.Info($"Error al intentar conectar a la base de datos: {ex.Message}");

                _log.Info("Limpia el cache y obtiene una nueva cadena de conexión.");
                ClearConnectionStringCache();

                _log.Info("Reintenta obtener la cadena de conexión.");
                string newConnectionString = GetCachedConnectionString();
                var connection = new SqlConnection(newConnectionString);
                return connection;
            }
        }

        // Obtiene la cadena de conexión desde el cache o consulta nuevamente si no está en cache
        private string GetCachedConnectionString()
        {
            if (_cachedConnectionString == null)
            {
                _log.Info("Bloquea el acceso para evitar problemas de concurrencia.");
                lock (_lock)
                {
                    _log.Info("Verifica nuevamente después de adquirir el lock.");
                    if (_cachedConnectionString == null)
                    {
                        //_cachedConnectionString = GetDataConn();
                        _cachedConnectionString = _connectionsConfig.Value.USE_MASTERCON ? GetDataConn() : _connectionsConfig.Value.DATA_MART;
                    }
                }
            }
            return _cachedConnectionString;
        }

        // Método para limpiar el cache de la cadena de conexión (cuando exista un fallo)
        private void ClearConnectionStringCache()
        {
            _log.Info("Bloquea el acceso para evitar problemas de concurrencia.");
            lock (_lock) 
            {
                _cachedConnectionString = null;
            }
        }

        // Método que consulta la cadena de conexión
        private string GetDataConn()
        {
            string connectionString = _dbConnectionString.GetDataConn(_connectionsConfig.Value.APP_NAME, _connectionsConfig.Value.APP_DB);
            connectionString += "Max Pool Size=100;Min Pool Size=0; Timeout=30;";
            _log.Info("Coneccion DB.");
            return connectionString;
        }

        public SqlConnection GetConexion()
        {
            string cadena = string.Empty;
            try
            {
                // Validar que _connectionsConfig no sea nulo
                if (_connectionsConfig?.Value == null)
                {
                    _log.Info("La configuración de conexiones no está inicializada");
                    throw new InvalidOperationException("La configuración de conexiones no está inicializada.");

                }

                // Obtener la cadena de conexión según la configuración
                // _log.Info(string.Format("Obtener la cadena de conexión según la configuración -> usa Masterconn: {0}", _connectionsConfig.Value.USE_MASTERCON ? "SI" : "NO"));                
                cadena = _connectionsConfig.Value.USE_MASTERCON ? GetDataConn() : _connectionsConfig.Value.DATA_MART;
                //_log.Info(string.Format("Cadena de conexion a usar {0}", cadena)); 
                // Crear y devolver la conexión
                var connection = new SqlConnection(cadena);
                return connection;
            }
            catch (Exception ex)
            {
                throw; // Propagar la excepción para que el consumidor maneje el error
            }
        }


    }
}
