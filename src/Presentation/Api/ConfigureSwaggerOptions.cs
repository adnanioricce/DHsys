//https://github.com/microsoft/aspnet-api-versioning/blob/master/samples/aspnetcore/SwaggerODataSample/ConfigureSwaggerOptions.cs
namespace Api
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;    
    using Microsoft.Extensions.Options;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using Microsoft.OpenApi.Models;
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;

    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    /// <remarks>This allows API versioning to define a Swagger document per API version after the
    /// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        //readonly IApiVersionDescriptionProvider provider;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        ///// </summary>
        ///// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        //public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            //foreach (var description in provider.ApiVersionDescriptions)
            //{
            //    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            //    options.AddSecurityDefinition("oauth2",new OpenApiSecurityScheme {
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.OAuth2,
            //        BearerFormat = "JWT",
            //        In = ParameterLocation.Header,
            //        OpenIdConnectUrl = new Uri($"https://localhost:5001/.well-known/openid-configuration"),
            //        Flows = new OpenApiOAuthFlows
            //        {
            //            ClientCredentials = new OpenApiOAuthFlow
            //            {
            //                AuthorizationUrl = new Uri($"https://localhost:5001/connnect/authorize"),
            //                TokenUrl = new Uri($"https://localhost:5001/connect/token"),
            //                Scopes = new Dictionary<string, string>
            //                {
            //                    { "swagger", "for demo purposes" }
            //                },
            //            }                       
            //        }
            //    });
            //    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "oauth2"
            //                },
            //                Scheme = "oauth2",
            //                Name = "Bearer",
            //                In = ParameterLocation.Header,

            //            },
            //            new List<string>()
            //        }
            //    });                
            //}
        }

        //static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        //{
        //    var info = new OpenApiInfo()
        //    {
        //        Title = "DHsys API",
        //        Version = description.ApiVersion.ToString(),
        //        Description = "DHsys is a inventory/POS system used as a test of some concepts.",
        //        Contact = new OpenApiContact() { Name = "adnan ioricce ", Email = "adnanioricce@outlook.com" },
        //        License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
        //    };

        //    if (description.IsDeprecated)
        //    {
        //        info.Description += " This API version has been deprecated.";
        //    }

        //    return info;
        //}
    }
}
