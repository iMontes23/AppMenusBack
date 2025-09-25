using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Navistar.Business.Core.Menus;
using Navistar.Business.Core.Security;
using Navistar.Business.CoreImp.Menu;
using Navistar.Business.CoreImp.Security;
using Navistar.DAO.Core;
using Navistar.DAO.CoreImp.Configuracion;
using Navistar.Model.common;
using Navistar.Model.common.Configuracion;
using Navistar.Model.Request;
using Navistar.Model.Request.Configuracion;
using Navistar.Repository.Carga.Menu;
using Navistar.Repository.Carga.Security;
using Navistar.Repository.CargaImp.Menu;
using Navistar.Repository.CargaImp.Security;
using Navistar.Web.API.Providers;

namespace Navistar.Web.API
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<MensajeRequest, MensajeAplicacion>();
                configuration.CreateMap<GeneralRequest, General>();
            }, typeof(Startup));

            // DAO
            services.AddScoped<IMensajeDAO, MensajeDAOImp>();

            // Repository
            services.AddScoped<IUserAccessRepository, UserAccessRepository>();
            services.AddScoped<IMenuRepository, MenuRepositoryImp>();

            // Business
            services.AddScoped<IMenuBusiness, MenuBusinessImp>();
            services.AddScoped<IUserAccessBusiness, UserAccessBusinessImp>();

            // Singleton
            services.AddScoped<ISecurity, Security>();
        }
    }
}
