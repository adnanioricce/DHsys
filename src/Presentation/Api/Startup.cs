using System;
using System.Linq;
using System.Reflection;
using Api.Extensions;
using Application.Extensions;
using DAL.DbContexts;
using DAL.Identity;
using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api
{
    public class Startup 
    {
        protected IConfiguration Configuration { get; }
        protected IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration,IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            ConfigureAppSettings();
            services.AddDomainValidators();
            services.AddApplicationServices();
            services.AddAutoMapperConfiguration();            
            services.AddApiDataStore();
            services.ConfigureApi(Environment);            
            services.AddAspNetIdentityIdentity(Configuration);
            services.AddCustomAuthentication(this.Environment);
            services.AddCors(options => {
                options.AddPolicy("Default",policy => {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });
            services.ConfigureApi(this.Environment);
            services.AddOdataConfiguration();
            services.AddSwaggerConfiguration();
            services.AddRouting(options => {
                options.LowercaseUrls = true;
            });
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
            
        }        
    }
}
