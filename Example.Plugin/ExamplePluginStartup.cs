using Infrastructure.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Composition;

namespace Example.Plugin
{
    [Export(typeof(IPluginInitialization))]
    public class ExamplePluginStartup : IPluginInitialization
    {
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment env;
        public IConfiguration Configuration => config;
        public IWebHostEnvironment Environment => env;        
        [ImportingConstructor]
        public ExamplePluginStartup(IConfiguration configuration,IWebHostEnvironment webHostEnvironment)
        {
            config = configuration;
            env = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<GrettingsService>();
        }

        public void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {

        }
    }
}
