using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Logging;

namespace DAL.DbContexts
{
    public class DHsysContextFactory : IDesignTimeDbContextFactory<DHsysContext>
    {
        public DHsysContext CreateDbContext(string[] args)
        {
            AppLogger.Log.Information($"Creating Db Context");
            var optionsBuilder = new DbContextOptionsBuilder<DHsysContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=2424;Database=dhsysdb_dev;Pooling=true;");            
            return new DHsysContext(optionsBuilder.Options);
        }
        public DHsysContext CreateContext(string connectionString,bool isDevelopment = false)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DHsysContext>();
            optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
            if (isDevelopment)
            {
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.EnableSensitiveDataLogging();
            }
            return new DHsysContext(optionsBuilder.Options);
        }        
    }
}
