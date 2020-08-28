using DAL;
using DAL.DbContexts;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace MigrationBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<RemoteContext>();
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=migration-placeholder;Trusted_Connection=True;MultipleActiveResultSets=true",
            //    m => m.MigrationsAssembly(Assembly.GetAssembly(typeof(DALAssembly))
            //                                      .GetName().Name));
            //optionsBuilder.EnableDetailedErrors();
            //optionsBuilder.EnableSensitiveDataLogging();
            //var context = new RemoteContext(optionsBuilder.Options);
            //context.ApplyUpgrades();

        }
    }
}
