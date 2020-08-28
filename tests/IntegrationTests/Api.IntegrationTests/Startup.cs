using Application;
using Application.Extensions;
using Application.Services;
using Core.Interfaces;
using DAL;
using DAL.DbContexts;
using DAL.Extensions;
using Infrastructure.Interfaces;
using Infrastructure.Logging;
using Infrastructure.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
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
            string sqliteConnString = $"DataSource=./Data/{Guid.NewGuid().ToString()}.db";
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("./appsettings.json")
                .Build();                    
            var dbSettingsSection = configuration.GetSection(nameof(LegacyDatabaseSettings));                
            var settings = new LegacyDatabaseSettings(dbSettingsSection["Provider"]
            ,"./TestData/"
            ,dbSettingsSection["ExtendedProperties"]
            ,dbSettingsSection["UserID"]
            ,dbSettingsSection["Password"]);
            //services
            services.Configure<LegacyDatabaseSettings>(configuration.GetSection(nameof(LegacyDatabaseSettings)));
            services.Configure<GitSettings>(configuration.GetSection(nameof(GitSettings)));
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));            
            services.AddDbContextPool<BaseContext,LocalContext>((opt) => {
                opt.UseLazyLoadingProxies();
                opt.UseSqlite(sqliteConnString);
            }).AddEntityFrameworkProxies();
            services.AddDbContextPool<BaseContext, RemoteContext>((opt) => {
                opt.UseLazyLoadingProxies();
                opt.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
            }).AddEntityFrameworkProxies();
            services.AddScoped(typeof(LegacyContext<>));
            services.AddScoped<BaseContext, LocalContext>();
            services.AddScoped<BaseContext, RemoteContext>();
            services.AddTransient<DbContextResolver>(provider => key => {
                string option = key.ToLower();
                var services = provider.GetServices(typeof(BaseContext));                
                return option switch
                {
                    "remote" => (BaseContext)services.FirstOrDefault(d => (d is RemoteContext)),
                    "local" => (BaseContext)services.FirstOrDefault(d => (d is LocalContext)),
                    _ => (BaseContext)services.FirstOrDefault(d => (d is LocalContext))
                };
            });
            services.ConfigureAppDataFolder();
            services.AddApplicationUpdater();
            services.AddApplicationServices();
            services.AddCustomMappers();
            services.AddAutoMapperConfiguration();
            services.ConfigureWritable<AutoUpdateSettings>();
            services.AddTransient(typeof(IAppLogger<>),typeof(LoggerAdapter<>));
            services.AddTransient<ConnectionResolver>(db => key =>  {                
                return key switch
                {
                    //our local database
                    "local" => new SQLiteConnection(sqliteConnString),
                    //a legacy shared database from which source changes in real world environment
                    "source" => new OleDbConnection(settings.ToString()),
                    //a remote database to keep some changes
                    "remote" => new SqlConnection(configuration.GetConnectionString("SqlServerConnection")),
                    _ => throw new KeyNotFoundException("there is no IDbConnection registered that match the given key"),
                };                
            });      
            services.AddTransient<ILegacyDbSynchronizer, LegacyDbSynchronizer>();                        
        }
        protected override void Configure(IServiceProvider provider)
        {
            using (var scope = provider.CreateScope()){
                var sp = scope.ServiceProvider;
                sp.GetServices<BaseContext>()
                    .ToList()
                    .ForEach(c => {
                        if ((c.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                        {                                       
                            c.ApplyUpgrades();
                        }
                        else
                        {
                            c.Database.Migrate();
                        }
                    });                          
            }
            base.Configure(provider);
        }
        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>        
            base.CreateHostBuilder(assemblyName)
                .ConfigureServices(ConfigureServices);
        
    }
}
