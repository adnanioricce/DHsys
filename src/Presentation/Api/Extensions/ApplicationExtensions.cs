using DAL.DbContexts;
using DAL.Extensions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Api.Extensions
{
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Dynamically create <see cref="EntitySetConfiguration{TEntityType}"/> for each Dto in Core.ApplicationModels.Dtos, add it to the odata configuration and enable default operations on routes.
        /// the default operations enabled are: Select, Expand, Filter, OrderBy, MaxTop, Count
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureOdata(this IApplicationBuilder app)
        {
            var odataBuilder = new ODataConventionModelBuilder(app.ApplicationServices);
            var dtoTypes = GetEntitiesDtos().Where(t => !t.Name.Contains("Item"));
            odataBuilder.AddTypesToOdataEntitySet(dtoTypes.ToArray());
            app.UseMvc(routeBuilder =>
            {                
                routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                routeBuilder.MapODataServiceRoute("ODataRoute", "api", odataBuilder.GetEdmModel());
                routeBuilder.EnableDependencyInjection();
            });
        }
        /// <summary>
        /// Add given all given <see cref="Type"/> objects with a Id Property to the <see cref="ODataConventionModelBuilder"/> list of <see cref="EntitySetConfiguration"/> 
        /// </summary>
        /// <param name="odataModelBuilder">the <see cref="ODataConventionModelBuilder"/> instance used to build the odata conventions</param>
        /// <param name="types">the given types to be mapped and added to the <see cref="EntitySetConfiguration"/> collection</param>
        /// <returns>the given instance of <see cref="ODataConventionModelBuilder"/> with a <see cref="EntitySetConfiguration"/> item for each <see cref="Type"/> given</returns>
        public static ODataConventionModelBuilder AddTypesToOdataEntitySet(this ODataConventionModelBuilder odataModelBuilder,params Type[] types)
        {
            foreach (var type in types)
            {
                if (!type.GetProperties().Any(d => d.Name == "Id"))
                {
                    continue;
                }                
                odataModelBuilder.AddEntitySet(type.Name, odataModelBuilder.AddEntityType(type));
            }
            odataModelBuilder.ModelAliasingEnabled = true;
            return odataModelBuilder;
        }
        /// <summary>
        /// Get all <see cref="Type"/> objects with name that ends with "Dto"
        /// </summary>
        /// <returns><see cref="Type"/> collection with name that ends with "Dto"</returns>
        public static IEnumerable<Type> GetEntitiesDtos()
        {
            return Assembly.GetAssembly(typeof(Core.Core))
                           .GetTypes()
                           .Where(t => t.IsClass && t.Name.EndsWith("Dto"));
        }
        /// <summary>
        /// try to build database and apply pending migrations for <see cref="LocalContext"/> of the caller Application
        /// </summary>
        /// <param name="application"></param>        
        public static void BuildDatabase(this IApplicationBuilder application,string applicationCallerTypeName)
        {                                    
            using var scope = application.ApplicationServices.CreateScope();
            if (applicationCallerTypeName == "Api")
            {
                var context = scope.ServiceProvider.GetServices<BaseContext>().FirstOrDefault(c => c is RemoteContext);
                context.ApplyUpgrades();
            }
            if (applicationCallerTypeName == "Desktop")
            {
                var context = scope.ServiceProvider.GetServices<BaseContext>().FirstOrDefault(c => c is LocalContext);
                context.ApplyUpgrades();
            }
        }
        public static bool DatabaseExists(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<RemoteContext>())
                {
                    return (context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists();
                }
            }
            
        }
    }
}
