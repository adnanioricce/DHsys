using System;
using System.Reflection;
using Api.Extensions;
using Application.Extensions;
using DAL.DbContexts;
using DAL.Identity;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
            ConfigureAppSettings();
            services.AddDomainValidators();
            services.AddApplicationServices();
            services.AddAutoMapperConfiguration();            
            services.AddApiDataStore();
            ConfigureApi();
            AddAuthentication();
            void AddAuthentication(){
                var migrationsAssembly = Assembly.GetExecutingAssembly().GetName().Name;
                string identityConnStr = Configuration.GetSection("Identity:Db")["Identity"];
                string configConnStr = Configuration.GetSection("Identity:Db")["Configuration"];
                string operationalConnStr = Configuration.GetSection("Identity:Db")["Operational"];
                services.AddDbContext<IdentityContext>(options => options.UseNpgsql(identityConnStr));
                services.AddIdentity<AppUser,IdentityRole>()
                        .AddEntityFrameworkStores<IdentityContext>()
                        .AddDefaultTokenProviders();
                var builder = services.AddIdentityServer()                        
                                    .AddConfigurationStore(options => {
                                        options.ConfigureDbContext = builder => builder.UseNpgsql(configConnStr, sql => sql.MigrationsAssembly(migrationsAssembly));
                                    })
                                    .AddOperationalStore(options => {
                                        options.ConfigureDbContext = builder => builder.UseNpgsql(operationalConnStr, sql => sql.MigrationsAssembly(migrationsAssembly));
                                        options.EnableTokenCleanup = true;                            
                                    })                        
                                    .AddAspNetIdentity<AppUser>();
                if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"){
                    builder.AddDeveloperSigningCredential();                    
                }
                services.AddAuthentication("Bearer")
                        .AddJwtBearer("Bearer",options => {
                            options.Authority = "https://localhost:5001";
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateAudience = false
                            };
                        });
            }
            void ConfigureAppSettings(){
                var configuration = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json")
                                        .AddEnvironmentVariables()
                                        .Build();
                services.Configure<ConnectionStrings>(Configuration.GetSection(nameof(ConnectionStrings)));
                services.ConfigureWritable<ConnectionStrings>();            
            }
            void ConfigureApi(){
                services.AddMvc(options => {
                    options.EnableEndpointRouting = false;
                }).AddNewtonsoftJson(settings => {
                    settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
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
            }                      
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {            
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
            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {                                
                endpoints.MapControllers();
            });
            
        }        
    }
}
