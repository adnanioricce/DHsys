using Application;
using Application.Extensions;
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
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddDesktopDataStore(configuration, rOpt => rOpt.UseNpgsql(configuration.GetConnectionString("NpgsqlConnection")));
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
            services.AddAutoMapperConfiguration();
            services.ConfigureWritable<AutoUpdateSettings>();
            services.AddTransient(typeof(IAppLogger<>),typeof(LoggerAdapter<>));
            services.AddTransient<ConnectionResolver>(db => key =>  {                
                return key switch
                {
                    //our local database
                    "local" => new SQLiteConnection(sqliteConnString),
                    //a legacy shared database from which source changes in real world environment
                    //TODO: Move legacy tests and operations in its own test project
                    //"source" => new OleDbConnection(settings.ToString()),                    
                    //a remote database to keep some changes
                    "remote" => new NpgsqlConnection(configuration.GetConnectionString("NpgsqlConnection")),
                    _ => throw new KeyNotFoundException("there is no IDbConnection registered that match the given key"),
                };                
            });            
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
