using System.Linq;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.DbContexts
{
    public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        string GetConnectionString(){
            return "";
        }
        public IdentityContext CreateDbContext(string[] args)
        {            
            var connStr = args.Length > 0
                ? args[0]
                : "User ID=postgres;Password=postgres;Host=localhost;Port=2424;Database=dhsysusers_db;Pooling=true;";
            return CreateDbContext(connStr);
        }
        public IdentityContext CreateDbContext(string connectionString){
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
            optionsBuilder.UseNpgsql(connectionString);
            var context = new IdentityContext(optionsBuilder.Options);                
            return context;
        }
    }
}