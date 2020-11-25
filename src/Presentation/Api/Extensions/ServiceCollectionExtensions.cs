using Core.Interfaces;
using DAL;
using DAL.DbContexts;
using Infrastructure.Settings;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;

namespace Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add OData services and configures it's input and output media formats
        /// </summary>
        /// <param name="services"></param>
        /// <returns>a instance of <see cref="IServiceCollection"/> with the added services and options for OData support</returns>
        public static IServiceCollection AddOdataSupport(this IServiceCollection services)
        {
            services.AddOData()
                .EnableApiVersioning();
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters
                                                       .OfType<ODataOutputFormatter>()
                                                       .Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters
                                                      .OfType<ODataInputFormatter>()
                                                      .Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
            return services;
        }
        /// <summary>
        /// Add Default data services for the Api application
        /// </summary>
        /// <param name="services">instance of <see cref="IServiceCollection"/> used to registers application services</param>
        public static void AddApiDataStore(this IServiceCollection services)
        {
            services.AddTransient<RemoteContextFactory>();
            services.AddDbContext<BaseContext, RemoteContext>((sp,options) => {
                var configuration = sp.GetService<IConfiguration>();
                var environment = configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT");                
                if (GlobalConfiguration.IsDockerContainer) {
                    string connectionString = GlobalConfiguration.DhConnectionString;
                    options.UseNpgsql(connectionString);
                    return;
                }
                var opt = sp.GetService<IWritableOptions<ConnectionStrings>>();
                if (environment == "Development")
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                    options.UseNpgsql(opt.Value.DevConnection);
                    return;
                }
                
                options.UseNpgsql(opt.Value.RemoteConnection);
             });
            services.AddScoped<BaseContext, RemoteContext>(provider => {
                var factory = provider.GetService<RemoteContextFactory>();
                var configuration = provider.GetService<IConfiguration>();
                var environment = configuration.GetValue<string>("environment");
                if (GlobalConfiguration.IsDockerContainer) {
                    string connectionString = GlobalConfiguration.DhConnectionString;
                    return factory.CreateContext(connectionString);
                }
                var options = provider.GetService<IWritableOptions<ConnectionStrings>>();
                if (environment == "Development") {
                    return factory.CreateContext(options.Value.DevConnection,isDevelopment:true);
                }                
                
                return factory.CreateContext(options.Value.RemoteConnection);                
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
