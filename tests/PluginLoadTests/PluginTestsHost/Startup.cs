using Infrastructure.Plugins;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using Weikio.PluginFramework.Catalogs;

namespace PluginTestsHost
{
    public class Startup
    {        
        protected IWebHostEnvironment Environment { get; }
        protected IConfiguration Configuration { get; }
        private PluginLoader PluginLoader;        
        [ImportMany]
        public IEnumerable<Lazy<IPluginInitializerFactory>> PluginFactories { get; set; }
        public Startup(IConfiguration configuration,IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;            
            var pluginAssemblies = Directory.GetFiles(Configuration["Plugins:Directory"])
                                            .Select(pluginAssembly => Assembly.LoadFrom(pluginAssembly))
                                            .ToArray();
            PluginLoader = PluginLoader.Create(typeof(Program).Assembly,pluginAssemblies);
            PluginLoader.ComposeOn(this);      
            var container = PluginLoader.GetCompositionContainer();
            PluginFactories = container.GetExports<IPluginInitializerFactory>();            
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;                
            })
            .AddNewtonsoftJson(settings => {
                settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddApiVersioning(options => options.ReportApiVersions = true);
            services.AddOData()
                .EnableApiVersioning();
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters
                                                       .OfType<ODataOutputFormatter>()
                                                       .Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters
                                                      .OfType<ODataInputFormatter>()
                                                      .Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
            services.AddODataApiExplorer();
            services.AddControllers()
            .ConfigureApplicationPartManager(partManager =>
            {
                foreach(var pluginAssembly in PluginLoader.GetPluginAssemblies()){                
                    partManager.ApplicationParts.Add(new AssemblyPart(pluginAssembly));
                }
            })
            .AddControllersAsServices();            
            foreach (var configureServices in PluginFactories.Select(e => e.Value.GetConfigureServicesFactory()))
            {
                configureServices(Configuration,Environment,services);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            foreach(var configureApplication in PluginFactories.Select(p => p.Value.GetConfigureApplicationFactory()))
            {
                configureApplication(Configuration,app,env,provider);
            }            
        }
    }
}
