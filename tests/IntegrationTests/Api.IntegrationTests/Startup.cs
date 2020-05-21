using Application;
using Application.Extensions;
using Application.Services;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Mappers;
using DAL;
using Infrastructure.Interfaces;
using Infrastructure.Logging;
using Infrastructure.Settings;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;
[assembly: TestFramework("Api.IntegrationTests.Startup", "Api.IntegrationTests")]
namespace Api.IntegrationTests
{
    public class Startup : DependencyInjectionTestFramework
    {
        public Startup(IMessageSink messageSink) : base(messageSink)
        {

        }
        public virtual void Configure()
        {

        }        
        protected void ConfigureServices(IServiceCollection services) 
        {            
            
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            string sqliteConnStr = configuration.GetConnectionString("SqliteConnection");
            string npgConnStr = configuration.GetConnectionString("NpgsqlConnection");
            var dbSettingsSection = configuration.GetSection(nameof(LegacyDatabaseSettings));                
            var settings = new LegacyDatabaseSettings(dbSettingsSection["Provider"]
            ,"./TestData/"
            ,dbSettingsSection["ExtendedProperties"]
            ,dbSettingsSection["UserID"]
            ,dbSettingsSection["Password"]);
            
            services.Configure<LegacyDatabaseSettings>(configuration.GetSection(nameof(LegacyDatabaseSettings)));
            services.Configure<GitSettings>(configuration.GetSection(nameof(GitSettings)));
            services.Configure<AppSettings>(configuration);
            services.AddDbContext<DbContext, MainContext>(opt => opt.UseSqlite("./Data/database.db"));            
            services.AddScoped(typeof(LegacyContext<>));
            services.AddScoped<MainContext>();            
            services.ConfigureAppDataFolder();
            services.AddApplicationUpdater();
            services.AddApplicationServices();
            services.AddCustomMappers();
            services.AddTransient(typeof(IAppLogger<>),typeof(LoggerAdapter<>));
            services.AddTransient<ConnectionResolver>(db => key =>  {                
                return key switch
                {
                    //our local database
                    "local" => new SQLiteConnection(sqliteConnStr),
                    //a legacy shared database from which source changes in real world environment
                    "source" => new OleDbConnection(settings.ToString()),
                    //a remote database to keep some changes
                    "remote" => new NpgsqlConnection(npgConnStr),
                    _ => throw new KeyNotFoundException("there is no IDbConnection registered that match the given key"),
                };                
            });      
            services.AddTransient<IDbSynchronizer, DbSynchronizer>();                        
        }
        protected override void Configure(IServiceProvider provider)
        {
            using (var scope = provider.CreateScope()){
                var sp = scope.ServiceProvider;
                var context = sp.GetService<DbContext>();
                if (context.Database.EnsureDeleted()){
                    context.Database.ExecuteSqlRaw(context.Database.GenerateCreateScript());
                    return;
                }
                context.Database.Migrate();                
            }
            base.Configure(provider);
        }
        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>        
            base.CreateHostBuilder(assemblyName)
                .ConfigureServices(ConfigureServices);
        
    }
}
