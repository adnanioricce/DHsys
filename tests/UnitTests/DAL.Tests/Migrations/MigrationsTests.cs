using DAL.DbContexts;
using DAL.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DAL.Tests.Migrations
{
    public class MigrationsTests
    {
        [Fact]
        public void Given_New_Database_Migration_Created_When_User_Tries_To_Get_Migration_Script_Then_Is_A_Secure_Migration_Script()
        {
            // Given
            var context = CreateContext();

            //When 
            var migrationScripts = context.GetPendingMigrationScripts();

            //Then
            var connection = context.Database.GetDbConnection();
            connection.Open();
            var hasFails = migrationScripts.Any(m => 
            {
                var command = connection.CreateCommand();
                command.CommandText = m;
                int result = command.ExecuteNonQuery();
                return result < 0;                
            });
            connection.Close();
            Assert.False(hasFails);
        }
        private DHsysContext CreateContext()
        {
            var context = new DHsysContext(CreateOptions(new SqliteConnection($"DataSource=:memory:")));
            return context;
        }

        private DbContextOptions<DHsysContext> CreateOptions(SqliteConnection connection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DHsysContext>();
            optionsBuilder.UseSqlite(connection);
            return optionsBuilder.Options;
        }
    }
}
