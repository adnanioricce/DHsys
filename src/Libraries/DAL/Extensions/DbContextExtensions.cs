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
            }
            if(context is LocalContext)
            {
                context = context as LocalContext ?? throw new InvalidCastException($"can't cast context {context} to LocalContext");
            }            
            var connection = context.Database.GetDbConnection();
            string connStr = connection.ConnectionString;
            string dbParameterSubstring = connStr.Substring(connStr.IndexOf("Database="));
            dbParameterSubstring = dbParameterSubstring.Substring(0, dbParameterSubstring.IndexOf(";") + 1);
            int start = dbParameterSubstring.IndexOf("=") + 1;
            int end = dbParameterSubstring.IndexOf(";");
            string databaseName = dbParameterSubstring.Substring(start ,end - start);
            string dbParameterAndValue = dbParameterSubstring.Substring(0,dbParameterSubstring.IndexOf(";"));            
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
            }catch(Exception ex)
            {
                AppLogger.Log.Error("Database is already created, or connection string is wrong. Given exception:{@ex}",ex);
            }
            AppLogger.Log.Information("Applying Migrations");
            connection.ChangeDatabase(databaseName);
            connection.Close();                        
            var migrator = context.Database.GetService<IMigrator>();
            var pendingMigrations = context.GetPendingMigrationScripts().Select(s => s.Replace("\r\nGO", " "))
                                                                        .ToList();           
            if (pendingMigrations.Any())
            {                
                pendingMigrations.ForEach(migration => {
                    try
                    {
                        context.Database.ExecuteSqlRaw(migration);
                        AppLogger.Log.Information("Migrations Applied");
                    }catch(Exception ex)
                    {
                        AppLogger.Log.Error("Exception throwed when trying to apply migration to Database Context. Exception Throwed:{@ex} \n Given Context: {@context} \n Migration:{@migration} \n", ex, context, migration);                        
                    }
                });
            }
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
            //If you don't do this, ef will try to execute migration from another context
            var pendingMigrations = context.Database.GetPendingMigrations().Where(m => {
                return m.Contains(context.Database.IsSqlite() ? "sqlite" : context.Database.IsNpgsql() ? "npgsql" : "sqlserver");
                }).ToList();
            var scriptsEnum = pendingMigrations.GetEnumerator();
            var idempotent = !context.Database.IsSqlite();
            var migrator = context.Database.GetService<IMigrator>();
            var scripts = pendingMigrations.Select(m => migrator.GenerateScript(toMigration:m,idempotent:idempotent));
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
            if (context.Database.IsSqlServer())
            {
                var _backupFileName = string.IsNullOrEmpty(backupFileName) ? _dbname : backupFileName;
                string backupScript = $@"BACKUP DATABASE {_dbname} to DISK=N'{_backupFileName}.bak' WITH FORMAT, INIT, STATS=10;";
                context.Database.ExecuteSqlRaw(backupScript);
            }
            else
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
            if (context.Database.IsSqlServer())
            {
                context.Database.ExecuteSqlRaw($@"  USE master;
                                                ALTER DATABASE {_dbname}
                                                SET SINGLE_USER                                                
                                                WITH ROLLBACK IMMEDIATE
                                                RESTORE DATABASE {_dbname} FROM DISK = '{backupFileName}.bak' WITH REPLACE");
            }
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
