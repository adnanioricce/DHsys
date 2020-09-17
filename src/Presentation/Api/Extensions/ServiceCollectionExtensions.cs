using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add OData services and configures it's input and output media formats
        /// </summary>
        /// <param name="services"></param>
        /// <returns>a instance of <see cref="IServiceCollection"/> with the added services and options for OData support</returns>
        public static IServiceCollection AddOdataSupport(this IServiceCollection services)
        {
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
            return services;
        }
    }
}
