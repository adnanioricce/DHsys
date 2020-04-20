using System.Linq;
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

[assembly: TestFramework("Api.Tests.DIStartup", "Api.Tests")]
namespace Api.Tests
{
    public class DIStartup : DependencyInjectionTestFramework
    {
        public DIStartup(IMessageSink messageSink) : base(messageSink)
        {
        }
        protected void ConfigureServices(IServiceCollection services) 
        {
            services.AddDbContext<DbContext, MainContext>(opt => {
                opt.UseSqlite("./Data/database.db");
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
            services.AddTransient<IDataResourceClient, SupplierDataResourceClient>();
            services.AddTransient<IDbSynchronizer, DbSynchronizer>();
            
        }
        protected override IHostBuilder CreateHostBuilder(System.Reflection.AssemblyName assemblyName){
            return base.CreateHostBuilder(assemblyName)
                .ConfigureServices(ConfigureServices);
        }
        protected override void Configure(IServiceProvider provider)
        {
            var context = (MainContext)provider.GetService<MainContext>();
            if(context.Database.EnsureDeleted()){
                context.Database.ExecuteSqlRaw(context.Database.GenerateCreateScript());
            }
            context.SeedDataForIntegrationTests(DrugSeed.GetDataForHttpGetMethods().ToArray());
        }
    }
}
