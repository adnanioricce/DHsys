using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Plugins
{
    public delegate void ConfigureServices(IConfiguration configuration,IWebHostEnvironment environment,IServiceCollection serviceCollection);
    public delegate void ConfigureApplication(IConfiguration configuration,IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider);    
    public delegate IPluginInitialization CreatePluginInitialization(IConfiguration configuration,IWebHostEnvironment environment);
    public interface IPluginInitialization
    {
        IConfiguration Configuration { get; }
        IWebHostEnvironment Environment { get; }
        void ConfigureServices(IServiceCollection serviceCollection);
        void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider);
    }
}
