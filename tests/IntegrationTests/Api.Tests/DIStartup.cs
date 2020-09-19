using System.Linq;
using Api.Tests.Seed;
using Application.Services;
using Core.Entities.Catalog;
using Core.Interfaces;
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
using DAL.DbContexts;
using Microsoft.Data.SqlClient;
using Application.Extensions;
using Api.Controllers.Api;

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
            services.AddDataStore(configuration);
            services.AddTransient<DbContextResolver>(provider => key => {
                string option = key.ToLower();
                var services = provider.GetServices(typeof(BaseContext));
                return option switch
                {
                    
                    _ => (BaseContext)services.FirstOrDefault(d => (d is LocalContext))
                };
            });                                
            services.AddTransient(typeof(IRepository<>),typeof(Repository<>));            
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IDrugService, DrugService>();
            services.AddTransient<IBillingService, BillingService>();                        
            services.AddAutoMapperConfiguration();            
            services.AddTransient<ConnectionResolver>(db => key => {
                return key switch
                {
                    //our local database
                    "local" => new SQLiteConnection(sqliteConnStr),                    
                    //a remote database to keep some changes
                    "remote" => new NpgsqlConnection(configuration.GetConnectionString("RemoteConnection")),
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
            var contexts = provider.GetServices<BaseContext>().ToList();
            contexts.ForEach(context => context.ApplyUpgrades());
        }
    }
}
