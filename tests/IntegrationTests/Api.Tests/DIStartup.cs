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
using Api;
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
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            services.AddTransient<DHsysContextFactory>();
            services.AddDbContext<DbContext, DHsysContext>((sp,options) => {
                var factory = sp.GetService<DHsysContextFactory>();
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                if(global::Api.GlobalConfiguration.IsDockerContainer){
                    string connectionString = global::Api.GlobalConfiguration.DhConnectionString;
                    options.UseNpgsql(connectionString);
                    return;
                }
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<DbContext, DHsysContext>((sp) => {
                var factory = sp.GetService<DHsysContextFactory>();
                if(global::Api.GlobalConfiguration.IsDockerContainer){                    
                    return factory.CreateContext(global::Api.GlobalConfiguration.DhConnectionString);
                }
                return factory.CreateContext(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IBillingService, BillingService>();
            services.AddAutoMapperConfiguration();
        }
        protected override IHostBuilder CreateHostBuilder(System.Reflection.AssemblyName assemblyName){
            return base.CreateHostBuilder(assemblyName)
                .ConfigureServices(ConfigureServices);
        }
        protected override void Configure(IServiceProvider provider)
        {
            var contexts = provider.GetServices<DHsysContext>().ToList();
            contexts.ForEach(context => context.ApplyUpgrades());
        }
    }
}
