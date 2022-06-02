using System.Linq;
using Api.Extensions;
using Application.Extensions;
using Infrastructure.Identity;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.AspNetCore.Mvc.Versioning;

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
            services.AddApiVersioning(p =>
            {                
                p.AssumeDefaultVersionWhenUnspecified = true;
                p.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                p.ReportApiVersions = true;
                p.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("ver"));
            });

            
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json","V1");
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
