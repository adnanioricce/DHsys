using Core.Interfaces;
using DAL.DbContexts;
using Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;
using System;
using System.Collections.Generic;
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
    public delegate IRepository<T> RepositoryResolver<T>(BaseContext context);
    public delegate BaseContext DbContextResolver(string key);
    public static class DbContextExtensions
    {
        /// <summary>
        /// Execute migrations not applied to the current <see cref="BaseContext"/> instance
        /// </summary>
        /// <param name="context">the <see cref="BaseContext"/> instance to apply the database migrations</param>
        public static void ApplyUpgrades(this BaseContext context)
        {
            if(context is RemoteContext)
            {
                context = context as RemoteContext ?? throw new InvalidCastException($"can't cast context {context} to RemoteContext");
                ((RemoteContext)context).PrepareRemote();
            }
            if(context is LocalContext)
            {
                context = context as LocalContext ?? throw new InvalidCastException($"can't cast context {context} to LocalContext");
            }            
            
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
        /// <param name="context">The <see cref="RemoteContext"/> of the remote database </param>
        public static void PrepareRemote(this RemoteContext context)
        {
            var connection = context.Database.GetDbConnection();
            string connStr = connection.ConnectionString;
            string dbParameterSubstring = connStr.Substring(connStr.IndexOf("Database="));
            dbParameterSubstring = dbParameterSubstring.Substring(0, dbParameterSubstring.IndexOf(";") + 1);
            int start = dbParameterSubstring.IndexOf("=") + 1;
            int end = dbParameterSubstring.IndexOf(";");
            string databaseName = dbParameterSubstring.Substring(start, end - start);
            string dbParameterAndValue = dbParameterSubstring.Substring(0, dbParameterSubstring.IndexOf(";"));
            connection.ConnectionString = connection.ConnectionString.Replace(dbParameterAndValue, "Database=postgres;");
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
        /// Returns list of Sql script strings of each migration not applied in current <see cref="BaseContext"/>
        /// </summary>
        /// <param name="context">The <see cref="BaseContext"/> to get pending migrations </param>
        /// <returns>a list Sql Scripts of each migration not applied in context</returns>
        public static IEnumerable<string> GetPendingMigrationScripts(this BaseContext context)
        {
            if (context is RemoteContext)
            {
                context = context as RemoteContext ?? throw new InvalidCastException($"can't cast context {context} to RemoteContext");                
            }
            if (context is LocalContext)
            {
                context = context as LocalContext ?? throw new InvalidCastException($"can't cast context {context} to LocalContext");
            }            
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
                if(string.IsNullOrEmpty(toMigration) && string.IsNullOrEmpty(previousMigration))
                {
                    scripts.Add(migrator.GenerateScript());
                    return scripts;
                }
                scripts.Add(migrator.GenerateScript(previousMigration, toMigration));
                previousMigration = toMigration;
            } while (pendingEnum.MoveNext());
            return scripts;
        }
        /// <summary>
        /// Creates a database backup for the current context (OBS: This is MSSQL specific). 
        /// <para>If no value is provided for the backupFileName parameter, backupFileName is equal to the database name</para>
        /// </summary>
        /// <param name="context">the <see cref="RemoteContext"/> instance </param>
        /// <param name="dbName">the name of the database to backup. Default is database name finded in the connection string. </param>
        /// <param name="backupFileName">name of the backup file(.bak)</param>
        public static void CreateDatabaseBackup(this RemoteContext context,string backupFileName = "",string dbName = "")
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
        /// <param name="context">the <see cref="RemoteContext"/> instance </param>
        /// <param name="dbName">the name of the database to restore </param>
        /// <param name="backupFileName">the name of the backup filename </param>
        public static void RestoreDatabase(this RemoteContext context, string backupFileName,string dbName = "")
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
        /// <param name="context">the <see cref="RemoteContext"/> instance </param>
        /// <returns>the database name string </returns>
        public static string GetDatabaseName(this RemoteContext context)
        {
            return context.Database.GetDbConnection().Database;
        }
    }
}
