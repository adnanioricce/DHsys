using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public static class ApplicationExtensions
    {
        public static void BuildDatabase(this IApplicationBuilder application,IWebHostEnvironment env)
        {
            if (!env.IsDevelopment()) return;

            var dbContext = (DbContext)application.ApplicationServices.GetService(typeof(DbContext));
            dbContext.Database.EnsureCreated();
            //if (dbContext.Database.EnsureDeleted())
            //{
            //    var sqlScript = dbContext.Database.GenerateCreateScript();
            //    dbContext.Database.ExecuteSqlRaw(sqlScript);                
            //    return;
            //}
            //dbContext.Database.Migrate();
        }
    }
}
