using Application.Mapping.Domain;
using Application.Services;
using AutoMapper;
using Core.Entities.Catalog;
using Core.Entities.Legacy;
using Core.Interfaces;
using Core.Interfaces.Catalog;
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

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //? I think is valid to remember that you still have to configure the option model before calling this
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
        public static void ConfigureAppDataFolder(this IServiceCollection services,string myFolder = "DHsys")
        {
            //TODO:Use isolation storage instead
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),myFolder);
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
        public static void AddApplicationUpdater(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var settings = provider.GetService<IOptions<AutoUpdateSettings>>();
            var logger = provider.GetService<IAppLogger<Updater>>();
            var writer = provider.GetService <IWritableOptions<AutoUpdateSettings>>();
            var updater = new Updater(logger,writer,settings);
            services.AddSingleton(typeof(IUpdater),updater);
        }           
        public static void AddApplicationServices(this IServiceCollection services)
        {            
            services.AddTransient<IDrugService, DrugService>();            
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IBillingService, BillingService>();
            services.AddTransient<ITransactionService, TransactionService>();
        }
        public static void AddDataStore(this IServiceCollection services,
            IConfiguration configuration,
            Action<DbContextOptionsBuilder> localContextOptions = null,
            Action<DbContextOptionsBuilder> remoteContextOptions = null)
        {            
            services.AddDbContextPool<BaseContext, LocalContext>(opt =>
            {                
                //opt.UseLazyLoadingProxies();
                //string connStr = configuration.GetValue<string>("AppSettings:DatabaseSettings:ConnectionStrings:LocalConnection");
                //if (localContextOptions == null)
                //{
                //    opt.UseSqlite(connStr);
                //    return;
                //}
                localContextOptions(opt);
            });
            services.AddDbContextPool<BaseContext, RemoteContext>(opt =>
            {
                //opt.UseLazyLoadingProxies();
                //string connStr = configuration.GetValue<string>("AppSettings:DatabaseSettings:ConnectionStrings:RemoteConnection");
                //if (remoteContextOptions == null)
                //{
                //    opt.UseNpgsql(connStr);
                //    return;
                //}
                remoteContextOptions(opt);
                //TODO:
            });
            services.AddScoped<BaseContext, LocalContext>();
            services.AddScoped<BaseContext, RemoteContext>();            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
        public static void ConfigureApplicationOptions(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.Configure<DatabaseSettings>(configuration.GetSection($"{nameof(AppSettings)}:{nameof(DatabaseSettings)}"));            
            services.Configure<AutoUpdateSettings>(configuration.GetSection($"{nameof(AppSettings)}:{nameof(AutoUpdateSettings)}"));
            services.Configure<ConnectionStrings>(configuration.GetSection($"{nameof(AppSettings)}:{nameof(ConnectionStrings)}"));
            services.ConfigureApplicationWritableOptions();
        }
        public static void ConfigureApplicationWritableOptions(this IServiceCollection services)
        {
            services.ConfigureWritable<AutoUpdateSettings>();            
            services.ConfigureWritable<ConnectionStrings>();
            services.ConfigureWritable<DatabaseSettings>();
            services.ConfigureWritable<AppSettings>();
        }        
        public static void TryCreateDatabase(this IServiceProvider provider, BaseContext context)
        {            
            context.Database.Migrate();            
        }
        public static void AddAutoMapperConfiguration(this IServiceCollection services) 
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CatalogProfile());
                cfg.AddProfile(new FinancialProfile());
            });
            var mapper = mapperConfig.CreateMapper();            
            services.AddSingleton(mapper);
        }              
    }
}
