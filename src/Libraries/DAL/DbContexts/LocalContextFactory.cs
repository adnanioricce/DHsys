using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace DAL.DbContexts
{
    public class LocalContextFactory : IDesignTimeDbContextFactory<LocalContext>
    {
        public LocalContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LocalContext>();
            optionsBuilder.UseSqlite("Data Source=migration-placeholder.db");
            return new LocalContext(optionsBuilder.Options);
        }
        public LocalContext CreateContext(string connectionString,bool isDevelopment = false)
        {
            //Duplicated code...
            var optionsBuilder = new DbContextOptionsBuilder<LocalContext>();
            optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
            if (isDevelopment)
            {
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.EnableSensitiveDataLogging();
            }
            return new LocalContext(optionsBuilder.Options);
        }
    }
}
