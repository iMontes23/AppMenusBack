using Mastercon;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Navistar.Model.common;
using System;

namespace Navistar.DataContext
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class DBDataMartEntityFmwImp : DbContext
    {
        Masterconnect_Interface _dbConnectionString;
        private readonly IOptions<ConnectionsConfig> connectionConfig;


 

        #region Configuración
        public DbSet<MensajeAplicacion> TCTRA_MensajeApp { get; set; }
        #endregion



        public DBDataMartEntityFmwImp(DbContextOptions<DBDataMartEntityFmwImp> options, IOptions<ConnectionsConfig> connectionConfig) : base(options)
        {
            this.connectionConfig = connectionConfig;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            #region Configuraciones
            modelBuilder.Entity<MensajeAplicacion>().ToTable("TCTRA_MensajeApp", "dbo");
            modelBuilder.Entity<MensajeAplicacion>().HasIndex(m => m.Key).IsUnique();
            #endregion

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _dbConnectionString = new Masterconnect();

            try
            {
                string cadena = _dbConnectionString.GetDataConn(connectionConfig.Value.APP_NAME, connectionConfig.Value.DataMartDB) + ";Timeout=600;";
                optionsBuilder.UseSqlServer(cadena); // MasterConn
                //optionsBuilder.UseSqlServer(connectionConfig.Value.RutasTransladosDB); // appsettings
            }
            catch (Exception exception)
            {
                var message = exception.Message;
            }
        }

    }

}

