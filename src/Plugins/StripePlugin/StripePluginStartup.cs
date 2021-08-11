using System;
using Infrastructure.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StripePlugin.Services;
using StripePlugin.Services.Interface;

namespace StripePlugin
{
    public class Startup : IPlugin
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration,IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        public void ConfigureServices(IServiceCollection serviceCollection)
        {            
            serviceCollection.AddTransient<IStripePaymentService,StripePaymentService>();
        }
        public void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {

        }        
    }
}
