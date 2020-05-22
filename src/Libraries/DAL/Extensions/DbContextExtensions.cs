using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Extensions
{
    public static class DbContextExtensions
    {
        public static void ApplyUpgrades(this DbContext context)
        {
            var migrator = context.Database.GetService<IMigrator>();
            var pendingMigrations = context.Database.GetPendingMigrations().ToList();
            if (pendingMigrations.Any())
            {                
                pendingMigrations.ForEach(migration => migrator.Migrate(migration));
            }
        }
        public static IEnumerable<string> GetPendingMigrationScripts(this DbContext context)
        {
            var migrator = context.Database.GetService<IMigrator>();
            var pendingMigrations = context.Database.GetPendingMigrations().ToList();            
            var scriptsEnum = pendingMigrations.GetEnumerator();            
            var scripts = pendingMigrations.Select(m => migrator.GenerateScript(toMigration:m));
            return scripts;
        }
    }
}
