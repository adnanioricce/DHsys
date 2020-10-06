using System;
using System.Linq;
using System.Reflection;
using Api.Extensions;
using Application.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api
{
    public class Startup 
    {
        protected IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddApplicationServices();
            services.ConfigureApplicationOptions(Configuration);
            services.AddAutoMapperConfiguration();
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;                
            }).AddNewtonsoftJson(settings => {
                settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });            
            services.AddDataStore(Configuration,Assembly.GetExecutingAssembly().GetName().Name);
            services.AddApiVersioning(options => options.ReportApiVersions = true);
            services.AddOdataSupport();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddODataApiExplorer();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();
                });
            var validators = Assembly.GetAssembly(typeof(Core.Core)).GetTypes()
                                                                    .Where(t => t.Namespace.StartsWith("Core.Validations"))
                                                                    .Where(t => !t.Name.StartsWith("BaseValidator"));
            foreach (var validator in validators)
            {
                services.AddTransient(validator.BaseType,validator);
            }
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {            
            app.ConfigureOdata();
            if (env.IsDevelopment())
            {
                //app.BuildDatabase(Assembly.GetExecutingAssembly().GetName().Name);
            }            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {                
                foreach (var description in provider.ApiVersionDescriptions)
                {
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
            app.UseAuthorization();            
            app.UseEndpoints(endpoints =>
            {                
                
                endpoints.MapControllers();                                
            });            
        }        
    }
}
