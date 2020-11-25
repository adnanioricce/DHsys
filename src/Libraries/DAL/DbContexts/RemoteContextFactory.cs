using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DbContexts
{
    public class RemoteContextFactory : IDesignTimeDbContextFactory<RemoteContext>
    {
        public RemoteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RemoteContext>();            
            optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=2424;Database=dhsysdb_dev;Pooling=true;");            
            return new RemoteContext(optionsBuilder.Options);
        }
        public RemoteContext CreateContext(string connectionString,bool isDevelopment = false)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RemoteContext>();
            optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
            if (isDevelopment)
            {
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.EnableSensitiveDataLogging();
            }
            return new RemoteContext(optionsBuilder.Options);
        }        
    }
}
