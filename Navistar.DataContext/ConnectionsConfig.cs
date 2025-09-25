 
namespace Navistar.DataContext
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class ConnectionsConfig
    { 
        //Connecciones directas en el appsettings 
        //DATABASES
        public string TransladosDB { get; set; }

        public string RutasTransladosDB { get; set; }

        public string DataMartDB { get; set; } 
        
        public string VentasDB { get; set; }
        
        public string RutasTelemetriaDB { get; set; }

        //Parametros para Mastercon   
        public string APP_NAME { get; set; }

        public string APP_DB { get; set; }

        public string APP_CODE { get; set; }
        public bool USE_MASTERCON { get; set; }
        public string DATA_MART { get; set; }

        public string RutasTransladosMultideckingDB { get; set; }
    }
}
