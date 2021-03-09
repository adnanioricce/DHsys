using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Tests.Lib
{
    public class DbContextHelper
    {
        public static DHsysContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DHsysContext>();
            optionsBuilder.UseNpgsql(new NpgsqlConnection($"User ID=postgres;Password=postgres;Host=localhost;Port=2424;Database=dhsysdb_dev;Pooling=true;"));
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();            
            var context = new DHsysContext(optionsBuilder.Options);                        
            return context;
        }
    }
}
