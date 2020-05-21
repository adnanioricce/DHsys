using Application.Extensions;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            using var scope = application.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MainContext>();            
            application.ApplicationServices.TryCreateDatabase(context);
        }
    }
}
