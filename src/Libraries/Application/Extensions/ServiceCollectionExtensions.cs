using Application.Mapping.Domain;
using Application.Services;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using MediatR;
using System.Linq;
using Core.Interfaces.Financial;
using Application.Services.Financial;
using Infrastructure.Logging;
using System.Reflection;
using DAL.DbContexts;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //? I think is valid to remember that you still have to configure the option model before calling this
        /// <summary>
        /// Configures a Writable version of a registered <see cref="IOptions{TOptions}"/>
        /// </summary>
        /// <typeparam name="T">The type of the Options Model</typeparam>
        /// <param name="services">the <see cref="IServiceCollection"/> in which <see cref="IWritableOptions{T}"/> should be registered </param>
        /// <param name="file">the settings file in which the Options value exists</param>
        public static void ConfigureWritable<T>(this IServiceCollection services,                        
            string file = "appsettings.json") where T : class, new()
        {            
            services.AddTransient<IWritableOptions<T>>(provider =>
            {
                var environment = provider.GetService<IHostEnvironment>();
                var options = provider.GetService<IOptionsMonitor<T>>();
                return new OptionWriter<T>(environment, options, file);
            });
        }                
        /// <summary>
        /// Add custom defined Application services to the <see cref="IServiceCollection"/> instance
        /// </summary>
        /// <param name="services">the <see cref="IServiceCollection"/> instance to add the application services</param>
        public static void AddApplicationServices(this IServiceCollection services)
        {            
            services.AddTransient<IProductService, ProductService>();            
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IBillingService, BillingService>();
            services.AddTransient<ITransactionService, POSOrderService>();
        }                
        public static void ConfigureApplicationOptions(this IServiceCollection services,IConfiguration configuration)
        {            
            services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
            services.ConfigureApplicationWritableOptions();
        }
        public static void ConfigureApplicationWritableOptions(this IServiceCollection services)
        {            
            services.ConfigureWritable<ConnectionStrings>();            
        }
        public static void TryCreateDatabase(this IServiceProvider provider, DHsysContext context)
        {
            context.Database.Migrate();
        }
        public static void AddAutoMapperConfiguration(this IServiceCollection services) 
        {                        
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddGlobalIgnore("CreatedAt");
                cfg.AddGlobalIgnore("LastUpdatedOn");
                cfg.AddGlobalIgnore("IsDeleted");
                cfg.AddProfile(new CoreProfile());
                cfg.AddProfile(new UpdateProfile());
                
            });
            mapperConfig.AssertConfigurationIsValid();
            var mapper = mapperConfig.CreateMapper();            
            services.AddSingleton(mapper);
        }              
    }
}
