using DAL.DbContexts;
using DAL.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace DAL.Tests.Extensions
{
    public class DbContextExtensionsTests
    {        
        [Fact]
        public void Given_Database_Without_A_Migration_Applied_When_Tries_To_Get_Missing_Migrations_Should_Return_Migration_Scripts()
        {
            // Given
            var context = CreateContext();

            //When 
            var migrationScripts = context.GetPendingMigrationScripts();

            //Then
            Assert.NotEmpty(migrationScripts);
        }
        [Fact]
        public void Given_Database_Without_Migrations_Applied_When_Tries_To_Apply_Upgrades_Then_Apply_migration_Scripts_If_No_Exception_Is_Throw()
        {
            // Given
            var context = CreateContext();            
            // When
            var result = Record.Exception(() => 
                {
                    context.Database.OpenConnection();
                    context.ApplyUpgrades();
                    context.Database.CloseConnection();
                }
            );     
            //Then
            Assert.Null(result);
        }

        private DHsysContext CreateContext()
        {
            var variables = Environment.GetEnvironmentVariables();
            return new DHsysContextFactory().CreateContext(Environment.GetEnvironmentVariable("CONNECTION_STRING"));            
        }

        private DbContextOptions<TContext> CreateOptions<TContext>(SqliteConnection connection) where TContext : DHsysContext
        {            
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlite(connection);
            return optionsBuilder.Options;
        }
    }
}
