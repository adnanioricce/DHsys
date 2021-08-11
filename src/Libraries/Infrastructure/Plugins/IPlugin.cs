using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Plugins
{
    public interface IPlugin
    {
        IConfiguration Configuration { get; }
        IWebHostEnvironment Environment { get; }
        void ConfigureServices(IServiceCollection serviceCollection);
        void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider);        
    }
}