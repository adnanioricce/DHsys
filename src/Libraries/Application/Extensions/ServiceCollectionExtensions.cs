﻿using Application.Mapping.Domain;
using Application.Services;
using Application.Services.Catalog;
using Application.Services.Sync;
using AutoMapper;
using Core.Entities.Catalog;
using Core.Entities.Legacy;
using Core.Interfaces;
using Core.Interfaces.Catalog;
using Core.Mappers;
using DAL;
using DAL.DbContexts;
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
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using MediatR;
using Core.Handlers;
using System.Linq;
using Core.Commands.Default;
using Core.Handlers.Financial;

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
            services.AddTransient<IDrugProdutoMediator, DrugProdutoMediator>();
            services.AddTransient<IDrugService, DrugService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IBillingService, BillingService>();
            services.AddTransient<ILegacyDbSynchronizer, LegacyDbSynchronizer>();
            services.AddTransient<ISyncQueryBuilder, SyncQueryBuilder>();
        }
        public static void AddDataStore(this IServiceCollection services,
            IConfiguration configuration,
            Action<DbContextOptionsBuilder> localContextOptions = null,
            Action<DbContextOptionsBuilder> remoteContextOptions = null)
        {            
            services.AddDbContextPool<BaseContext, LocalContext>(opt =>
            {                
                opt.UseLazyLoadingProxies();
                string connStr = configuration.GetValue<string>("AppSettings:DatabaseSettings:ConnectionStrings:LocalConnection");
                if (localContextOptions == null)
                {
                    opt.UseSqlite(connStr);
                    return;
                }
                localContextOptions(opt);
            });
            services.AddDbContextPool<BaseContext, RemoteContext>(opt =>
            {                
                opt.UseLazyLoadingProxies();
                string connStr = configuration.GetValue<string>("AppSettings:DatabaseSettings:ConnectionStrings:RemoteConnection");
                if (remoteContextOptions == null)
                {
                    opt.UseSqlServer(connStr);
                    return;
                }
                //TODO:
            });
            services.AddScoped<BaseContext,LocalContext>();
            services.AddScoped<BaseContext, RemoteContext>();            
            services.AddScoped(typeof(LegacyContext<>));
            services.AddTransient(typeof(ILegacyRepository<>), typeof(DbfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
        public static void ConfigureApplicationOptions(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.Configure<DatabaseSettings>(configuration.GetSection($"{nameof(AppSettings)}:{nameof(DatabaseSettings)}"));
            services.Configure<LegacyDatabaseSettings>(configuration.GetSection($"{nameof(AppSettings)}:{nameof(DatabaseSettings)}:{nameof(LegacyDatabaseSettings)}"));
            services.Configure<AutoUpdateSettings>(configuration.GetSection($"{nameof(AppSettings)}:{nameof(AutoUpdateSettings)}"));
            services.Configure<ConnectionStrings>(configuration.GetSection($"{nameof(AppSettings)}:{nameof(ConnectionStrings)}"));
            services.ConfigureApplicationWritableOptions();
        }
        public static void ConfigureApplicationWritableOptions(this IServiceCollection services)
        {
            services.ConfigureWritable<AutoUpdateSettings>();
            services.ConfigureWritable<LegacyDatabaseSettings>();
            services.ConfigureWritable<ConnectionStrings>();
            services.ConfigureWritable<DatabaseSettings>();
            services.ConfigureWritable<AppSettings>();
        }
        public static void AddCustomMappers(this IServiceCollection services)
        {
            services.AddTransient<ILegacyDataMapper<Drug, Produto>, ProdutoMapper>();
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
        public static void AddMediator<TStartup>(this IServiceCollection services)
        {
            var assembly = typeof(DefaultCreateHandler<>).Assembly;            
            services.AddScoped(typeof(IRequestHandler<,>),typeof(DefaultReadHandler<,>));
            services.AddScoped(typeof(IRequestHandler<,>), typeof(DefaultCreateHandler<>));
            services.AddScoped<BillingHandler>();
            services.AddMediatR(services.Where(s => s.ServiceType == typeof(IRequestHandler<,>)).Select(s => s.ImplementationType).ToArray());
            //services.AddMediatR()
        }        
    }
}
