﻿using System.Linq;
using Api.Tests.Seed;
using Application.Services;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Mappers;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Tests.Lib.Extensions;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Application;
using System.Data.SQLite;
using System.Data.OleDb;
using Npgsql;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.IO;
using DAL.Extensions;

[assembly: TestFramework("Api.Tests.DIStartup", "Api.Tests")]
namespace Api.Tests
{
    public class DIStartup : DependencyInjectionTestFramework
    {
        // private string sqliteConnStr = "";
        public DIStartup(IMessageSink messageSink) : base(messageSink)
        {
        }
        protected void ConfigureServices(IServiceCollection services) 
        {
            string sqliteConnStr = $"DataSource={Guid.NewGuid().ToString()}.db";
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            services.AddDbContext<DbContext, MainContext>(opt => {
                opt.UseSqlite(sqliteConnStr);
                opt.EnableSensitiveDataLogging();
                opt.EnableDetailedErrors();                
            });                
            services.AddScoped(typeof(LegacyContext<>));
            services.AddScoped<MainContext>();
            services.AddTransient(typeof(ILegacyRepository<>), typeof(DbfRepository<>));         
            services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
            services.AddTransient<ILegacyDataMapper<Drug,Produto>, ProdutoMapper>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IDrugService, DrugService>();
            services.AddTransient<IBillingService, BillingService>();
            //services.AddTransient<IDataResourceClient, SupplierDataResourceClient>();
            services.AddTransient<IDbSynchronizer, DbSynchronizer>();
            services.Configure<LegacyDatabaseSettings>(configuration.GetSection(nameof(LegacyDatabaseSettings)));
            var legacySettings = configuration.GetSection(nameof(LegacyDatabaseSettings)).Get<LegacyDatabaseSettings>();
            services.AddTransient<ConnectionResolver>(db => key => {
                return key switch
                {
                    //our local database
                    "local" => new SQLiteConnection(sqliteConnStr),
                    //a legacy shared database from which source changes in real world environment
                    "source" => new OleDbConnection(legacySettings.ToString()),
                    //a remote database to keep some changes
                    "remote" => new NpgsqlConnection(""),
                    _ => throw new KeyNotFoundException("there is no IDbConnection registered that match the given key"),
                };
            });

        }
        protected override IHostBuilder CreateHostBuilder(System.Reflection.AssemblyName assemblyName){
            return base.CreateHostBuilder(assemblyName)
                .ConfigureServices(ConfigureServices);
        }
        protected override void Configure(IServiceProvider provider)
        {
            var context = (MainContext)provider.GetService<MainContext>();
            context.ApplyUpgrades();
            //if(!File.Exists("./Data/database.db")){
            //    context.Database.EnsureDeleted();
            //    string sql = context.Database.GenerateCreateScript();
            //    context.Database.ExecuteSqlRaw(sql);
            //    context.SeedDataForIntegrationTests(DrugSeed.GetDataForHttpGetMethods().ToArray());
            //}else {
            //    var migrations = context.Database.GetPendingMigrations();
            //    if(migrations.Any()){
            //        context.Database.Migrate();
            //    }
            //}            
            
        }
    }
}