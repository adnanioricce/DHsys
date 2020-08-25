using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Tests.Lib
{
    public class TestBase<TStartup> : IDisposable where TStartup : class
    {
        protected readonly string _dbname = "";
        protected readonly RemoteContext _dbContext;
        public TestBase(CustomWebApplicationFactory<TStartup> factory)
        {
            var scope = factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<RemoteContext>();
            var connection = dbContext.Database.GetDbConnection();
            _dbname = connection.Database;
            string backupScript = $@"BACKUP DATABASE {_dbname} to DISK=N'{_dbname}.bak' WITH FORMAT, INIT, STATS=10;";
            dbContext.Database.ExecuteSqlRaw(backupScript);
        }
        public virtual void Dispose()
        {
            //restore previous state when run backup query
            _dbContext.Database.ExecuteSqlRaw($@"USE master;
                                                ALTER DATABASE {_dbname}
                                                SET SINGLE_USER                                                
                                                WITH ROLLBACK IMMEDIATE
                                                RESTORE DATABASE {_dbname} FROM DISK = '{_dbname}.bak' WITH REPLACE");
        }
    }
}
