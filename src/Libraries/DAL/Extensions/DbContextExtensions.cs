using AutoMapper.QueryableExtensions;
using Core.Entities;
using Core.Interfaces;
using DAL.DbContexts;
using Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Extensions
{
    /// <summary>
    /// Delegate to resolve different implementations of IRepository.
    /// </summary>
    /// <typeparam name="T">the <see cref="Core.Entities.BaseEntity"/> type to be used</typeparam>
    /// <param name="repositoryType"><para> which database the repository should target.</para>
    /// options are
    /// <para>Local -> database used in a file,used only on current application scope</para>
    /// <para>Remote -> database server, used for multiple applications</para>           
    /// </param>
    /// <returns></returns>
    public delegate IRepository<T> RepositoryResolver<T>(DHsysContext context);
    public delegate DHsysContext DbContextResolver(string key);
    public static class DbContextExtensions
    {
        /// <summary>
        /// Execute migrations not applied to the current <see cref="DHsysContext"/> instance
        /// </summary>
        /// <param name="context">the <see cref="DHsysContext"/> instance to apply the database migrations</param>
        public static void ApplyUpgrades(this DHsysContext context)
        {                        
            var migrator = context.Database.GetService<IMigrator>();            
            var pendingMigrations = context.GetPendingMigrationScripts().ToList();
            if (pendingMigrations.Any())
            {
                pendingMigrations.ForEach(migration => {                    
                        var result = context.Database.ExecuteSqlRaw(migration);                                                                
                });
            }
        }        
        /// <summary>
        /// Creates the remote database without any migration or model
        /// </summary>
        /// <param name="context">The <see cref="DHsysContext"/> of the remote database </param>
        public static void PrepareRemote(this DHsysContext context)
        {
            var connection = context.Database.GetDbConnection();
            var databaseName = GetDatabaseName(connection);
            ChangeDatabase(connection,"postgres");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"CREATE DATABASE {databaseName};";
            try
            {
                var result = command.ExecuteNonQuery();
                if (result >= 0)
                {
                    AppLogger.Log.Information("Database created");
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log.Error("Database is already created, or connection string is wrong. Given exception:{@ex}", ex);
            }
            AppLogger.Log.Information("Applying Migrations");
            connection.ChangeDatabase(databaseName);
            connection.Close();            
        }        

        /// <summary>
        /// Change the database used for the given <see cref="IDbConnection"/>
        /// </summary>
        /// <param name="connection">The given <see cref="IDbConnection"/> in which database should be changed</param>
        /// <param name="newDatabaseName">The given <see cref="IDbConnection"/> in which database should be changed</param>
        /// <returns> the <see cref="IDbConnection"/> instance with the Database parameter changed to the given database name</returns>
        private static IDbConnection ChangeDatabase(IDbConnection connection,string newDatabaseName)
        {
            var dbNameAndValue = GetDatabaseName(connection);
            connection.ConnectionString = connection.ConnectionString.Replace($"Database={dbNameAndValue};", $"Database={newDatabaseName};");
            return connection;
        }        
        private static string GetDatabaseName(IDbConnection connection)
        {
            string connStr = connection.ConnectionString;
            string dbParameterSubstring = connStr[connStr.IndexOf("Database=")..];
            dbParameterSubstring = dbParameterSubstring.Substring(0, dbParameterSubstring.IndexOf(";"))["Database=".Length..];
            return dbParameterSubstring;            
        }
        /// <summary>
        /// Returns list of Sql script strings of each migration not applied in current <see cref="DHsysContext"/>
        /// </summary>
        /// <param name="context">The <see cref="DHsysContext"/> to get pending migrations </param>
        /// <returns>a list Sql Scripts of each migration not applied in context</returns>
        public static IEnumerable<string> GetPendingMigrationScripts(this DHsysContext context)
        {              
            var lastMigration = context.Database.GetAppliedMigrations().LastOrDefault();            
            var migrator = context.Database.GetService<IMigrator>();            
            var scripts = new List<string>();
            var pendingMigrations = context.Database.GetPendingMigrations();
            var pendingEnum = pendingMigrations.GetEnumerator();
            pendingEnum.MoveNext();
            string previousMigration = lastMigration;            
            do
            {
                var toMigration = pendingEnum.Current;
                if (string.IsNullOrEmpty(toMigration) && string.IsNullOrEmpty(previousMigration))
                {
                    scripts.Add(migrator.GenerateScript());
                }
                else
                {
                    scripts.Add(migrator.GenerateScript(previousMigration, toMigration));
                    previousMigration = toMigration;
                }
            } while (pendingEnum.MoveNext());
            return scripts;
        }
        /// <summary>
        /// Creates a database backup for the current context (OBS: This is MSSQL specific). 
        /// <para>If no value is provided for the backupFileName parameter, backupFileName is equal to the database name</para>
        /// </summary>
        /// <param name="context">the <see cref="DHsysContext"/> instance </param>
        /// <param name="dbName">the name of the database to backup. Default is database name finded in the connection string. </param>
        /// <param name="backupFileName">name of the backup file(.bak)</param>
        public static void CreateDatabaseBackup(this DHsysContext context,string dbName = "")
        {            
            var _dbname = string.IsNullOrEmpty(dbName) ? context.GetDatabaseName() : dbName;
            if(context.Database.IsNpgsql())           
            {                
                var result = context.Database.ExecuteSqlRaw(@$"SELECT datname FROM pg_catalog.pg_database WHERE lower(datname) = lower('{_dbname}_copy');");
                if (result == -1)
                {
                    return;
                }
                context.Database.ExecuteSqlRaw($@"CREATE DATABASE {_dbname}_copy WITH TEMPLATE {_dbname};");                
            }

        }
        /// <summary>
        /// Restore the database to the last backup. OBS: This is MSSQL specific
        /// </summary>
        /// <param name="context">the <see cref="DHsysContext"/> instance </param>
        /// <param name="dbName">the name of the database to restore </param>
        /// <param name="backupFileName">the name of the backup filename </param>
        public static void RestoreDatabase(this DHsysContext context,string dbName = "")
        {
            var _dbname = string.IsNullOrEmpty(dbName) ? context.Database.GetDbConnection().Database : dbName;            
            if (context.Database.IsNpgsql())
            {
                var connection = context.Database.GetDbConnection();
                
                connection.Open();
                connection.ChangeDatabase("postgres");
                var command = connection.CreateCommand();                
                command.CommandText = @$"SELECT pg_terminate_backend(pg_stat_activity.pid)
                                        FROM pg_stat_activity
                                        WHERE pg_stat_activity.datname = '{_dbname}'
                                          AND pid <> pg_backend_pid();
                                        DROP DATABASE {_dbname};
                                        CREATE DATABASE { _dbname} TEMPLATE {_dbname}_copy;                                                 
                                        DROP DATABASE {_dbname}_copy; ";
                command.ExecuteNonQuery();
                connection.ChangeDatabase(_dbname);
                connection.Close();
                
            }
        }
        /// <summary>
        /// Returns the name of the Database
        /// </summary>
        /// <param name="context">the <see cref="DHsysContext"/> instance </param>
        /// <returns>the database name string </returns>
        public static string GetDatabaseName(this DHsysContext context)
        {
            return context.Database.GetDbConnection().Database;
        }
        /// <summary>
        /// Builds a service provider with EF services used in the design time workflow, like <see cref="IMigrationsCodeGenerator"/>.
        /// </summary>
        /// <param name="context">The <see cref="DHsysContext"/> instance in whick get the design time services</param>
        /// <returns></returns>
        public static IServiceProvider BuildEFDesignTimeServiceProvider(this DHsysContext context)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddEntityFrameworkDesignTimeServices();
            serviceCollection.AddDbContextDesignTimeServices(context);
            return serviceCollection.BuildServiceProvider();
        }
        public static IMigrationsScaffolder GetMigrationsScaffolderService(this DHsysContext context)
        {
            var serviceProvider = context.BuildEFDesignTimeServiceProvider();
            return serviceProvider.GetService<IMigrationsScaffolder>();
        }
        public static IMigrationsCodeGenerator GetMigrationsCodeGenerator(this DHsysContext context)
        {
            var serviceProvider = context.BuildEFDesignTimeServiceProvider();
            return serviceProvider.GetService<IMigrationsCodeGenerator>();
        }
        public static (ScaffoldedMigration ScaffoldedMigration,IMigrationsScaffolder Scaffolder) ScaffoldMigration(this DHsysContext context,string migrationName,string rootNamespace)
        {
            var scaffolder = context.GetMigrationsScaffolderService();
            return (scaffolder.ScaffoldMigration(migrationName, rootNamespace), scaffolder);
        }
        //public static 
        public static MigrationFiles AddMigration(this DHsysContext context,string projectDir, string outputDir, string migrationName,string rootNamespace = "DAL")
        {
            var scaffolding = context.ScaffoldMigration(migrationName, rootNamespace);            
            return scaffolding.Scaffolder.Save(projectDir, scaffolding.ScaffoldedMigration, outputDir);
        }
        public static MigrationFiles DeleteMigration(this DHsysContext context, string projectDir, string rootNamespace)
        {
            var scaffolder = context.GetMigrationsScaffolderService();            
            return scaffolder.RemoveMigration(projectDir, rootNamespace, true, "?");            
        }        
    }
}
