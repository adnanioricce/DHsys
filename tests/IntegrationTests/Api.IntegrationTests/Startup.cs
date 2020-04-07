﻿using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Mappers;
using Core.Services;
using Core.Settings;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
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
        protected void ConfigureServices(IServiceCollection services) 
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            services.AddDbContext<DbContext, MainContext>(opt => opt.UseSqlite("./Data/database.db"));                
            services.AddScoped(typeof(LegacyContext<>));
            services.AddTransient(typeof(ILegacyRepository<>), typeof(DbfRepository<>));         
            services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
            services.AddTransient<ILegacyDataMapper<Drug,Produto>, ProdutoMapper>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IDrugService, DrugService>();
            services.AddTransient<IBillingService, BillingService>();
            services.AddTransient<IDataResourceClient, SupplierDataResourceClient>();
            services.Configure<LegacyDatabaseSettings>(configuration.GetSection(nameof(LegacyDatabaseSettings)));
            services.Configure<GitSettings>(configuration.GetSection(nameof(GitSettings)));
        }
        protected override void Configure(IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var sp = scope.ServiceProvider;
                var context = sp.GetService<DbContext>();
                if (context.Database.EnsureDeleted())
                {
                    context.Database.ExecuteSqlRaw(context.Database.GenerateCreateScript());
                }
                context.Database.Migrate();
                //var migrations = context.Database.GetMigrations();
                //if(migrations.Count() > 0) {
                //    foreach (var migration in migrations)
                //    {
                        
                //    }
                //}
            }
                base.Configure(provider);
        }
        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>        
            base.CreateHostBuilder(assemblyName)
                .ConfigureServices(ConfigureServices);
        
    }
}
