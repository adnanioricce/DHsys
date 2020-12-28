using DAL.DbContexts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Tests.Lib
{
    public class DbContextHelper
    {
        public static DHsysContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DHsysContext>();
            optionsBuilder.UseSqlite(new SqliteConnection($"DataSource=:memory:"));
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();            
            var context = new DHsysContext(optionsBuilder.Options);                        
            return context;
        }
    }
}
