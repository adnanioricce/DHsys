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
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dhsys-db;Trusted_Connection=True;MultipleActiveResultSets=true");
            //optionsBuilder.UseNpgsql("User ID=postgres;Password=asdf1234;Host=localhost;Port=5432;Database=migration-placeholder-db;Pooling=true;");            
            return new RemoteContext(optionsBuilder.Options);
        }
    }
}
