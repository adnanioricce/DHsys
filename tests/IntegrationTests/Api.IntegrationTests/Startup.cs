using Application.Services;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Mappers;
using DAL;
using Infrastructure.Settings;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
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
            services.Configure<LegacyDatabaseSettings>(configuration.GetSection(nameof(LegacyDatabaseSettings)));
            services.Configure<GitSettings>(configuration.GetSection(nameof(GitSettings)));
            services.Configure<AppSettings>(configuration);
            services.AddDbContext<DbContext, MainContext>(opt => opt.UseSqlite("./Data/database.db"));
            services.AddScoped<IDbConnection>(db => new SqliteConnection(configuration.GetConnectionString("SqliteConnection")));         
            services.AddScoped(typeof(LegacyContext<>));
            services.AddScoped<MainContext>();
            services.AddTransient(typeof(ILegacyRepository<>), typeof(DbfRepository<>));         
            services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
            services.AddTransient<ILegacyDataMapper<Drug,Produto>, ProdutoMapper>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IDrugService, DrugService>();
            services.AddTransient<IBillingService, BillingService>();
            services.AddTransient<IDataResourceClient, SupplierDataResourceClient>();
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
