using Application.Services.Identity;
using Core.Interfaces;
using DAL;
using DAL.DbContexts;
using Infrastructure.Identity;
using Infrastructure.Interfaces.Identity;
using Infrastructure.Services;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.OData.Edm;
using Core.ApplicationModels.Dtos.Catalog;

namespace Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainValidators(this IServiceCollection services)
        {
            var validators = Assembly.GetAssembly(typeof(Core.Core)).GetTypes()
                                                                    .Where(t => !string.IsNullOrEmpty(t.Namespace))
                                                                    .Where(t => t.Namespace.StartsWith("Core.Validations"))
                                                                    .Where(t => !t.Name.StartsWith("BaseValidator"));
            foreach (var validator in validators) {
                services.AddTransient(validator.BaseType,validator);
            }
            return services;
        }
        /// <summary>
        /// Add OData services and configures it's input and output media formats
        /// </summary>
        /// <param name="services"></param>
        /// <returns>a instance of <see cref="IServiceCollection"/> with the added services and options for OData support</returns>
        public static IServiceCollection AddOdataSupport(this IServiceCollection services)
        {
            // services.AddOData()
            //     .EnableApiVersioning();
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
            return services;
        }
        /// <summary>
        /// Add Default data services for the Api application
        /// </summary>
        /// <param name="services">instance of <see cref="IServiceCollection"/> used to registers application services</param>
        public static IServiceCollection AddApiDataStore(this IServiceCollection services)
        {
            services.AddTransient<DHsysContextFactory>();
            services.AddDbContext<DHsysContext, DHsysContext>((sp,options) => {
                var configuration = sp.GetService<IConfiguration>();
                var environment = configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT");                
                if (GlobalConfiguration.IsDockerContainer) {
                    string connectionString = GlobalConfiguration.DhConnectionString;
                    options.UseNpgsql(connectionString);
                    return;
                }
                var opt = sp.GetService<IWritableOptions<ConnectionStrings>>();
                if (environment == "Development")
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();                    
                    options.UseNpgsql(opt.Value.DevConnection);
                    return;
                }
                
                options.UseNpgsql(opt.Value.DefaultConnection);
             });
            services.AddScoped<DHsysContext, DHsysContext>(provider => {
                var factory = provider.GetService<DHsysContextFactory>();
                var configuration = provider.GetService<IConfiguration>();
                var environment = configuration.GetValue<string>("environment");
                if (GlobalConfiguration.IsDockerContainer) {                    
                    if(!String.IsNullOrEmpty(configuration.GetValue<string>("DATABASE_URL"))){
                        return factory.CreateContext(configuration.GetValue<string>("DATABASE_URL"));    
                    }
                    string connectionString = configuration.GetValue<string>("DH_CONNECTION_STRING");                    
                    return factory.CreateContext(connectionString);
                }
                var options = provider.GetService<IWritableOptions<ConnectionStrings>>();
                if (environment == "Development") {
                    return factory.CreateContext(options.Value.DevConnection,isDevelopment:true);
                }                
                
                return factory.CreateContext(options.Value.DefaultConnection);                
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }        
        public static IServiceCollection AddCorsAuthorization(this IServiceCollection services,IWebHostEnvironment environment){
            services.AddAuthorization(options => {
                if(environment.EnvironmentName == "Development"){
                    options.AddPolicy("Default",policy => {
                        policy.RequireAuthenticatedUser();                            
                        policy.RequireAssertion(context => {                                
                            return context.User.HasClaim(c => (c.Type == "scope" && c.Value == "swagger") || (c.Type == "scope" && c.Value == "dhsysapi"));
                        });
                    });
                }else {
                    options.AddPolicy("Default",policy => {
                        policy.RequireAuthenticatedUser();
                        policy.RequireClaim("scope","admin");
                        policy.RequireClaim("role","admin");
                    });
                }

            });
            return services;
        }
        public static IServiceCollection AddDefaultAuth(this IServiceCollection services,IConfiguration configuration,IWebHostEnvironment environment){
            var jwtTokenConfig = configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();            
            services.AddSingleton(jwtTokenConfig);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
            services.AddCorsAuthorization(environment);
            services.AddSingleton<IJwtAuthManager, DefaultJwtManager>();
            services.AddHostedService<JwtRefreshTokenCache>();
            services.AddTransient<IUserIdentityService, DefaultIdentityService>();            
            return services;
        }
        public static IServiceCollection AddAspNetIdentity(this IServiceCollection services,IConfiguration configuration){
            string identityConnStr = configuration.GetConnectionString("Identity");
            services.AddDbContext<IdentityContext>(options => options.UseNpgsql(identityConnStr));
            services.AddIdentity<AppUser,AppRole>()
                    .AddEntityFrameworkStores<IdentityContext>()
                    .AddDefaultTokenProviders();
            return services;
        }
        public static IServiceCollection ConfigureApi(this IServiceCollection services,IWebHostEnvironment environment)
        {
            IEdmModel GetEdmModel()
            {
                var model = new EdmModel();
                model.AddEntityType(typeof(ProductDto).Namespace,typeof(ProductDto).Name);
                return model;
            }
            services.AddControllersWithViews();
            services.AddMvcCore(options => {
                options.EnableEndpointRouting = false;
                if(environment.EnvironmentName == "Testing"){
                    options.Filters.Add<AllowAnonymousFilter>();
                }
            })
            .AddApiExplorer()
            .AddOData(options => {
                options.AddRouteComponents("odata",GetEdmModel());
            })
            .AddNewtonsoftJson(settings => {
                settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddApiVersioning(options => {
                options.ReportApiVersions = true;                
            });
            services.AddEndpointsApiExplorer();
            return services;
        }
        public static IServiceCollection AddOdataConfiguration(this IServiceCollection services){
            services.AddOdataSupport();
            //services.AddODataApiExplorer();
            return services;
        }
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services){
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();
                });
            return services;            
        }
    }
}
