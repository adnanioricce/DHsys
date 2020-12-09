using Application.Mapping.Domain;
using Application.Services;
using AutoMapper;
using Core.Interfaces;
using DAL;
using DAL.DbContexts;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Infrastructure.Updates;
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
        /// Creates a folder in the default AppData folder(Windows) to store configuration and data files
        /// </summary>
        /// <param name="services"></param>
        /// <param name="folderName">The folder name in which to store the configuration and data files</param>
        public static void ConfigureAppDataFolder(this IServiceCollection services,string folderName = "DHsys")
        {
            //TODO:Use isolation storage instead
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),folderName);
            if (!Directory.Exists(folder))
            {
                try{
                    Directory.CreateDirectory(folder);
                }catch(Exception ex)
                {
                    throw ex;
                }
            }
            //Create appsettings.json file on AppData Folder
            string appsettingsPath = Path.Combine(folder,"appsettings.json");
            if (!File.Exists(appsettingsPath))
            {
                if (File.Exists("appsettings.json"))
                {
                    var appsettingsContent = File.ReadAllLines("appsettings.json");                    
                    var lines = string.Join("\n", appsettingsContent);
                    File.WriteAllText(appsettingsPath, lines);
                    return;
                }
                File.Create(appsettingsPath);
            }
            //create updates folder on AppData Folder
            string updateFilesFolder = Path.Combine(folder,"Updates");
            if (!File.Exists(updateFilesFolder))
            {
                Directory.CreateDirectory(updateFilesFolder);
            }
        }
        /// <summary>
        /// Add singleton of a <see cref="IUpdater"/> implementation to handle Application Updates.
        /// OBS: Desktop specific.
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationUpdater(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var settings = provider.GetService<IOptions<AutoUpdateSettings>>();
            var logger = provider.GetService<IAppLogger<Updater>>();
            var writer = provider.GetService <IWritableOptions<AutoUpdateSettings>>();
            var updater = new Updater(logger,writer,settings);
            services.AddSingleton(typeof(IUpdater),updater);
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
        
        /// <summary>
        /// Add default data services and Database context.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration">the <see cref="IConfiguration"/> instance with the Connection String data</param>
        /// <param name="applicationName">The name of the calling application </param>
        /// <param name="contextOptionsAction">a custom action to configure custom options</param>
        public static void AddDesktopDataStore(this IServiceCollection services)
        {
            services.AddTransient<DbContextOptionsFactory>();
            services.AddTransient<DHsysContextFactory>();
            services.AddDbContext<DHsysContext, DHsysContext>((sp, options) =>
            {
                var configuration = sp.GetService<IConfiguration>();                                
                var opt = sp.GetService<IWritableOptions<ConnectionStrings>>();
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                options.UseNpgsql(opt.Value.DefaultConnection);
            });
            services.AddScoped<DHsysContext, DHsysContext>(sp => {
                var factory = sp.GetRequiredService<DHsysContextFactory>();                
                var options = sp.GetService<IWritableOptions<ConnectionStrings>>();
                return factory.CreateContext(options.Value.DefaultConnection);
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
        }
        public static void ConfigureApplicationOptions(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));            
            services.Configure<AutoUpdateSettings>(configuration.GetSection(nameof(AutoUpdateSettings)));
            services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
            services.ConfigureApplicationWritableOptions();
        }
        public static void ConfigureApplicationWritableOptions(this IServiceCollection services)
        {
            services.ConfigureWritable<AutoUpdateSettings>();            
            services.ConfigureWritable<ConnectionStrings>();
            services.ConfigureWritable<DatabaseSettings>();
            services.ConfigureWritable<AppSettings>();
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
