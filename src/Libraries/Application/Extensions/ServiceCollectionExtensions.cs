using Application.Services;
using Application.Services.Catalog;
using Application.Services.Sync;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Interfaces.Catalog;
using Core.Mappers;
using DAL;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Infrastructure.Updates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //? I think is valid to remember that you still have to configure the option model before calling this
        public static void ConfigureWritable<T>(this IServiceCollection services,
            string sectionKey,            
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
        public static void TryCreateDatabase(this IServiceProvider services,MainContext context)
        {
            //RelationalDatabaseCreator creator = services.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            //if(context.Database.)
            context.Database.Migrate();
            //if (!creator.Exists())
            //{
            //    creator.Create();
            //    creator.CreateTables();
            //}
            //context.Database.Migrate();
            //if (creator.Exists())
            //{
            //    //TODO:seed method
            //}
        }
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IDrugProdutoMediator, DrugProdutoMediator>();
            services.AddTransient<IDrugService, DrugService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IBillingService, BillingService>();
            services.AddTransient<IDbSynchronizer, DbSynchronizer>();
            services.AddTransient<ISyncQueryBuilder, SyncQueryBuilder>();
        }
        public static void AddCustomMappers(this IServiceCollection services)
        {
            services.AddTransient<ILegacyDataMapper<Drug, Produto>, ProdutoMapper>();
        }
    }
}
