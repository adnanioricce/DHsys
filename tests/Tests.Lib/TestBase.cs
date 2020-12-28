using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Tests.Lib
{
    public class TestBase<TStartup> : IDisposable where TStartup : class
    {
        protected readonly string _dbname = "";
        protected readonly DHsysContext _dbContext;        
        public TestBase(TestFixture<TStartup> fixture)
        {
            var scope = fixture.ServiceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DHsysContext>();
            var connection = dbContext.Database.GetDbConnection();
            _dbname = connection.Database;
            string backupScript = $@"CREATE DATABASE {_dbname}_copy WITH TEMPLATE {_dbname};";
            dbContext.Database.ExecuteSqlRaw(backupScript);
            _dbContext = dbContext;            
        }
        public virtual void Dispose()
        {
            //restore previous state when run backup query
            _dbContext.Database.ExecuteSqlRaw(@$"\c postgres;
                                                 DROP DATABASE {_dbname};
                                                 CREATE DATABASE { _dbname} TEMPLATE {_dbname}_copy;
                                                 \c {_dbname};
                                                 DROP DATABASE {_dbname}_copy; ");            
        }
    }
}
