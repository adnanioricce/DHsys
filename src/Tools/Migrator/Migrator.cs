using DAL.DbContexts;
using DAL.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Helper
{    
    public class Migrator
    {
        public static readonly string MigrationProjectDir = GetDALProjectDir();
        public static string GetDALProjectDir()
        {
            string name = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            
            while (!Directory.Exists(name + "/Libraries/DAL"))
            {
                name = Directory.GetParent(name).FullName;
            }
            return name + "/Libraries/DAL";
        }
        /// <summary>
        /// Add a new migration for the given context
        /// </summary>
        /// <param name="migrationName"></param>
        /// <param name="contextType"></param>
        public static void AddMigration(string migrationName, ContextType contextType)
        {            
            if (contextType == ContextType.Local)
            {
                var localContext = new LocalContextFactory().CreateDbContext(new[] { "" });
                var migrationFiles = localContext.AddMigration(MigrationProjectDir, $"{MigrationProjectDir}/Migrations/Local",string.Format("{0}-local",migrationName));
                Console.WriteLine("--- Files created ---");
                Console.WriteLine("MetadataFile: {0}", migrationFiles.MetadataFile);
                Console.WriteLine("MigrationFile: {0}", migrationFiles.MigrationFile);
                Console.WriteLine("SnapshotFile: {0}", migrationFiles.SnapshotFile);
            }
            else if(contextType == ContextType.Remote)
            {
                var remoteContext = new RemoteContextFactory().CreateDbContext(new[] { "" });
                var migrationFiles = remoteContext.AddMigration(MigrationProjectDir, $"{MigrationProjectDir}/Migrations/Remote", string.Format("{0}-remote", migrationName));
                Console.WriteLine("--- Files created ---");
                Console.WriteLine("MetadataFile: {0}", migrationFiles.MetadataFile);
                Console.WriteLine("MigrationFile: {0}", migrationFiles.MigrationFile);
                Console.WriteLine("SnapshotFile: {0}", migrationFiles.SnapshotFile);
            }            
        }                
        //public static void 
        /// <summary>
        /// Applies all remaining sql migrations for the given connection
        /// </summary>
        /// <param name="connectionString">the connection string of the database to be migrated</param>
        public static void Migrate(string connectionString)
        {
            var remoteContextFactory = new RemoteContextFactory();
            var remoteContext = remoteContextFactory.CreateContext(connectionString);
            try
            {
                remoteContext.ApplyUpgrades();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Migrations failed with the following error:{ex}");
            }
        }
    }
    
}
