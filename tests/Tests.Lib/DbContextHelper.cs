using DAL.DbContexts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Tests.Lib
{
    public class DbContextHelper
    {
        public static BaseContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BaseContext>();
            optionsBuilder.UseSqlite(new SqliteConnection($"DataSource=:memory:"));
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();            
            var context = new BaseContext(optionsBuilder.Options);                        
            return context;
        }
    }
}
