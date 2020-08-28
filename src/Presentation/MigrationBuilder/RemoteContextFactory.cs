using DAL;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace MigrationBuilder
{
    public class RemoteContextFactory : IDesignTimeDbContextFactory<RemoteContext>
    {
        public RemoteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RemoteContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=migration-placeholder;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new RemoteContext(optionsBuilder.Options);
        }
    }
}
