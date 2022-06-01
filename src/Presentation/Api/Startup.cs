using System;
using System.Linq;
using System.Reflection;
using Api.Controllers.Identity;
using Api.Extensions;
using Application.Extensions;
using Core.DI;
using DAL.DbContexts;
using Infrastructure.Identity;
using Infrastructure.Interfaces.Identity;
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
using Microsoft.AspNetCore.OData;

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
            
            services.AddDefaultAuth(Configuration,Environment);
            services.AddAspNetIdentity(Configuration);            
            services.AddCors(options => {
                options.AddPolicy("Default",policy => {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });
            // services.ConfigureApi(this.Environment);                        
            // services.AddOdataConfiguration();
            services.AddSwaggerConfiguration();
            services.AddRouting(options => {
                options.LowercaseUrls = true;
            });
            services.ConfigureApi(Environment);
            // Resolver.Initialize(services.BuildServiceProvider());
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();                 
            // app.ConfigureOdata();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                try{
                    // foreach (var description in provider.ApiVersionDescriptions) {
                    //     c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    // }
                    c.RoutePrefix = "api/v1";
                }catch(System.Exception ex){
                    Log.Error("A exception was thrwoed when trying to configure swagger:{@ex}",ex);
                }
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            // app.UseIdentityServer();            
            app.UseAuthorization();
            app.UseCors("Default");
            app.UseEndpoints(endpoints =>
            {                                
                endpoints.MapControllers().RequireCors("Default");
                
            }); 
            // app.UseMvc(routeBuilder => {
                // routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                // routeBuilder.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
            // });
            SeedDefaultUsers(app);
        }

        private void SeedDefaultUsers(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            // scope.ServiceProvider.CreateAsyncScope
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
            var users = userManager.Users.ToList();
            Log.Information("Users:{@users}",users);
            roleManager.CreateAsync(new AppRole(AppRole.Admin)).GetAwaiter().GetResult();
            roleManager.CreateAsync(new AppRole(AppRole.BasicUser)).GetAwaiter().GetResult();
            AppUser.GetAdminAsync(scope.ServiceProvider).GetAwaiter().GetResult();
        }
    }
}
