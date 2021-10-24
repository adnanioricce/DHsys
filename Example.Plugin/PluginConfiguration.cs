using Infrastructure.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Composition;

namespace Example.Plugin
{
    [Export(typeof(IPluginInitializerFactory))]
    public class PluginConfiguration : IPluginInitializerFactory
    {        
        public ConfigureServices GetConfigureServicesFactory()
            => ConfigureServices;
        public ConfigureApplication GetConfigureApplicationFactory()
            => ConfigureApplication;
        public CreatePluginInitialization GetPluginInitializationFactory()
            => CreatePluginInitialization;
        
        public static void ConfigureServices(IConfiguration configuration,
            IWebHostEnvironment environment,
            IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<GrettingsService>();
        }
        public static void ConfigureApplication(IConfiguration configuration,
            IApplicationBuilder app, 
            IWebHostEnvironment env, 
            IApiVersionDescriptionProvider provider)
        {
            
        }
        public static IPluginInitialization CreatePluginInitialization(IConfiguration configuration,
            IWebHostEnvironment environment)
            => new ExamplePluginStartup(configuration,environment);
        
    }
}
