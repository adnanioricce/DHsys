using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using Api.Controllers;
using Api.Controllers.Api;
using Api.Extensions;
using Application;
using Application.Extensions;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;
using Core.Validations;
using DAL.DbContexts;
using DAL.Extensions;
using FluentValidation;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Npgsql;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api
{
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {            
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddControllers();
            services.AddGrpc();
            

            services.AddMvc(options => {
                options.EnableEndpointRouting = false;                
            })

                .AddNewtonsoftJson(settings => {
                    settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;                    
                });            
            services.AddDataStore(Configuration, null);
            services.AddApiVersioning(options => options.ReportApiVersions = true);
            services.AddOData()
                .EnableApiVersioning();
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>()
                                                       .Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddODataApiExplorer();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();                    
                    // integrate xml comments
                    //if (!File.Exists(XmlCommentsFilePath))
                    //{
                    //    using (var fileStream = File.Create(XmlCommentsFilePath))
                    //    {
                    //        fileStream.Close();
                    //    }
                    //}
                    //options.IncludeXmlComments(XmlCommentsFilePath);
                });
            var validators = Assembly.GetAssembly(typeof(Core.Core)).GetTypes().Where(t => t.Namespace.StartsWith("Core.Validations"))
                                                                               .Where(t => !t.Name.StartsWith("BaseValidator"));
            foreach (var validator in validators)
            {
                services.AddTransient(validator.BaseType,validator);
            }
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            var odataBuilder = new ODataConventionModelBuilder(app.ApplicationServices);
            //odataBuilder.EntitySet<BillingDto>("Billing");
            var dtosTypes = Assembly.GetAssembly(typeof(Core.Core)).GetTypes()
                                                                       .Where(t => t.IsClass && t.Name.EndsWith("Dto") && !t.Name.Contains("Item"));

            foreach (var dtoType in dtosTypes)
            {
                if(!dtoType.GetProperties().Any(d => d.Name == "Id"))
                {
                    continue;
                }
                odataBuilder.AddEntitySet(dtoType.Name, odataBuilder.AddEntityType(dtoType));
            }
            odataBuilder.ModelAliasingEnabled = true;
            app.UseMvc(routeBuilder =>
            {
                //routeBuilder.ServiceProvider.GetRequiredService<ODataOptions>().UrlKeyDelimiter = Parentheses;
                routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                routeBuilder.MapODataServiceRoute("ODataRoute", "api",odataBuilder.GetEdmModel());
                routeBuilder.EnableDependencyInjection();
            });            

            app.BuildDatabase(env);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {                
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    
                }
                c.RoutePrefix = string.Empty;
            });
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
            
        }
        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
