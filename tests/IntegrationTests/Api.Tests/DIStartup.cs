using System.Linq;
using Application.Services;
using Core.Interfaces;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using DAL.Extensions;
using DAL.DbContexts;
using Application.Extensions;
using Microsoft.EntityFrameworkCore;

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
            services.AddTransient<RemoteContextFactory>();
            services.AddDbContext<BaseContext,RemoteContext>((sp,options) => {
                var factory = sp.GetService<RemoteContextFactory>();                
                options.UseNpgsql(configuration.GetConnectionString("DevConnection"));
            });
            services.AddScoped<BaseContext, RemoteContext>((sp) => {
                var factory = sp.GetService<RemoteContextFactory>();                
                return factory.CreateContext(configuration.GetConnectionString("DevConnection"));
            });
            services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IDrugService, DrugService>();
            services.AddTransient<IBillingService, BillingService>();
            services.AddAutoMapperConfiguration();
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
