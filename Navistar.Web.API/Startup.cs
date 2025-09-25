using log4net;
using Mastercon;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Navistar.DataContext;
using Navistar.Model.common.Configuracion;
using Navistar.Utils.Logger;
using System;

namespace Navistar.Web.API
{
    public class Startup
    {
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var allowedOrigins = Configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>();

            if (allowedOrigins == null || allowedOrigins.Length == 0)
            {
                throw new Exception("No se han configurado orígenes permitidos en la sección CorsSettings:AllowedOrigins.");
            }

            //services.Configure<ConnectionsConfig>(Configuration.GetSection("Traffilog"));
            services.Configure<ConnectionsConfig>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<ConnectionsConfig>(Configuration.GetSection("MasterConnectConfig"));

            ///Scope for database
            //services.AddScoped<DBDatamartImp>();
            services.AddTransient<Masterconnect_Interface, Masterconnect>();
            services.AddTransient<DBDatamartImp>();
            services.AddDbContext<DBDataMartEntityFmwImp>();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  //builder => builder.WithOrigins("http://nmxsvp70", "http://nmxsvp61", "https://evalue.internationaldelivers.com", "http://www.nmx.navistar.com")  //Version de Cliente
                  //builder => builder.WithOrigins("http://167.6.156.121", "https://evaluet.internationaldelivers.com", "http://localhost:8400", "http://nmxsvp70", "http://nmxsvp57")  //Version de QA
                  builder => builder.WithOrigins(allowedOrigins)
                  .WithMethods("GET","POST", "DELETE")
                  .AllowAnyHeader()
                  .AllowCredentials());
            });

            ServiceRegistration.AddInfrastructure(services);
            services.Configure<General>(Configuration.GetSection("GeneralesApp"));

            //Scope for Utils
            //services.AddScoped<Navistar.Utils.Logger.ILogger, Logger>();
            services.AddTransient<Navistar.Utils.Logger.ILogger, Logger>();

            services.AddControllers().AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Drm_API", Version = "v1.0" });
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.AddSingleton<ILog>(provider =>
            {
                return LogManager.GetLogger(typeof(Startup));
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /* The relevant part for Forwarded Headers */
            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Drm_API");
                });
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("./v1/swagger.json", "Drm_API");
                });
            }

            
            // No usar HTTPS redirection
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization(); 
         
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
