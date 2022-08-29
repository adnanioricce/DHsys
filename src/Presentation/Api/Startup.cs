using System;
using System.Linq;
using Api.Extensions;
using Application.Extensions;
using DAL.DbContexts;
using Infrastructure.Identity;
using Infrastructure.Logging;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Startup 
    {
        IConfiguration Configuration { get; }
        IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration,IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        void Log(string serviceBeingConfigured,string methodName, Action action)
        {
            AppLogger.Log.Information("Configuring {serviceBeingConfigured}...",serviceBeingConfigured);
            try
            {
                AppLogger.Log.Debug("Calling {methodName} method",methodName);
                action();
                AppLogger.Log.Debug("{methodName} call ended",methodName);
            }
            catch (Exception ex)
            {
                AppLogger.Log.Error("Failed to configure {serviceBeingConfigured}:{ex}",serviceBeingConfigured,ex);
            }
            AppLogger.Log.Information("Done!");
        }
        public void ConfigureServices(IServiceCollection services)
        {
            AppLogger.Log.Information($"Environment:{Environment.EnvironmentName}");
            Log("Application settings and env vars", "ConfigureAppSettings", () => ConfigureAppSettings());
            Log("domain validators", "AddDomainValidators", () => services.AddDomainValidators());
            Log("application services", "AddApplicationServices", () => services.AddApplicationServices());
            Log("Auto Mapper Configuration", "AddAutoMapperConfiguration", () => services.AddAutoMapperConfiguration());
            Log("Database", "AddApiDataStore", () => services.AddApiDataStore());
            Log("Authentication", "AddDefaultAuth", () => services.AddDefaultAuth(Configuration,Environment));
            Log("Authentication Database", "AddAspNetIdentity", () => services.AddAspNetIdentity(Configuration));
            Log("CORS", "AddCors", () => services.AddCors(options => {
                options.AddPolicy("Default",policy => {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
                AppLogger.Log.Debug("Policy 'Default' added");
            }));
            // services.ConfigureApi(this.Environment);                        
            // services.AddOdataConfiguration();
            AppLogger.Log.Debug("Calling IServiceCollection.AddApiVersioning");
            Log("API Versioning", "AddApiVersioning", () =>
                services.AddApiVersioning(p =>
                {
                    p.AssumeDefaultVersionWhenUnspecified = true;
                    p.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                    p.ReportApiVersions = true;
                    p.ApiVersionReader = ApiVersionReader.Combine(
                        new QueryStringApiVersionReader("api-version"),
                        new HeaderApiVersionReader("X-Version"),
                        new MediaTypeApiVersionReader("ver"));
                }));
            Log("API Documentation", "AddSwaggerConfiguration", () => services.AddSwaggerConfiguration());
            Log("API Routing", "AddRouting", () => services.AddRouting());
            Log("API Model", "ConfigureApi", () => services.ConfigureApi(Environment));
            void ConfigureAppSettings()
            {
                var env = Environment.EnvironmentName;
                var configurationBuilder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables();
                if (env != "Production")
                {
                    configurationBuilder.AddJsonFile($"appsettings.{env}.json");
                }

                var configuration = configurationBuilder.Build();
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json","V1");
                    c.RoutePrefix = "api/v1";
                }catch(System.Exception ex){
                    AppLogger.Log.Error("A exception was thrwoed when trying to configure swagger:{@ex}",ex);
                }
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            
            app.UseStaticFiles();
            app.UseHttpsRedirection();            
            app.UseRouting().UseApiVersioning();
            app.UseCors("Default");  
           
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {                                                
                endpoints.MapControllers().RequireCors("Default");
            }).UseApiVersioning();
            SeedDefaultUsers(app);
        }

        private void SeedDefaultUsers(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<IdentityContext>();
            ctx.Database.Migrate();
            // scope.ServiceProvider.CreateAsyncScope
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
            var users = userManager.Users.ToList();
            AppLogger.Log.Information("Users:{@users}",users);
            roleManager.CreateAsync(new AppRole(AppRole.Admin)).GetAwaiter().GetResult();
            roleManager.CreateAsync(new AppRole(AppRole.BasicUser)).GetAwaiter().GetResult();
            AppUser.GetAdminAsync(scope.ServiceProvider).GetAwaiter().GetResult();
        }
    }
}
