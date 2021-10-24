using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using Api.Extensions;
using Application.Extensions;
using Infrastructure.Plugins;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Api
{
    public class Startup 
    {
        protected IConfiguration Configuration { get; }
        protected IWebHostEnvironment Environment { get; }        
        protected PluginLoader PluginLoader;
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
            ConfigureAppSettings();
            // load plugin assemblies            
            services.AddDomainValidators();
            services.AddApplicationServices();
            services.AddAutoMapperConfiguration();            
            services.AddApiDataStore();
            services.ConfigureApi(PluginLoader,Environment);            
            services.AddAspNetIdentityIdentity(Configuration);
            services.AddCustomAuthentication(this.Environment);
            services.AddCors(options => {
                options.AddPolicy("Default",policy => {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });
            services.ConfigureApi(PluginLoader,this.Environment);
            services.AddOdataConfiguration();
            services.AddSwaggerConfiguration();
            services.AddRouting(options => {
                options.LowercaseUrls = true;
            });
            var container = PluginLoader.GetCompositionContainer();
            PluginFactories = container.GetExports<IPluginInitializerFactory>();
            foreach (var configureServices in PluginFactories.Select(e => e.Value.GetConfigureServicesFactory()))
            {
                configureServices(Configuration,Environment,services);
            }            
            void ConfigureAppSettings(){
                var configuration = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json")
                                        .AddEnvironmentVariables()
                                        .Build();
                services.Configure<ConnectionStrings>(Configuration.GetSection(nameof(ConnectionStrings)));
                services.ConfigureWritable<ConnectionStrings>();            
            }
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {            
            app.UseSerilogRequestLogging();                 
            app.ConfigureOdata();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions) {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
                c.RoutePrefix = "api/v1";
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseIdentityServer();            
            app.UseAuthorization();
            app.UseCors("Default");
            app.UseEndpoints(endpoints =>
            {                                
                endpoints.MapControllers().RequireCors("Default");
            });            
            foreach (var configureApplication in PluginFactories.Select(p => p.Value.GetConfigureApplicationFactory()))
            {                
                configureApplication(Configuration,app,env,provider);
            };
        }        
    }
}
