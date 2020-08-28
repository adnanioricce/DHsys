using Core.Entities;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Entities.Legacy;
using Core.Entities.Stock;
using Core.Interfaces;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        public static object ToContext(this BaseContext context,Type contextType)
        {
            if(contextType.Name == "LocalContext")
            {
                return context.ToContext<LocalContext>();
            }
            if(contextType.Name == "RemoteContext")
            {
                return context.ToContext<RemoteContext>();
            }
            throw new ArgumentException("the context can't be casted to the given TContext parameter. Either the context type don't exists or the context is not of the specified type");
        }
        public static TContext ToContext<TContext>(this BaseContext context) where TContext : BaseContext
        {
            if(!((context as TContext) is null))
            {
                return (TContext)context;
            }
            throw new ArgumentException("the context can't be casted to the given TContext parameter. Either the context type don't exists or the context is not of the specified type");
        }        
        public static void ApplyUpgrades(this BaseContext context)
        {
            if(context is RemoteContext)
            {
                context = context as RemoteContext ?? throw new InvalidCastException($"can't cast context {context} to RemoteContext");
                //if(context is null)
            }
            if(context is LocalContext)
            {
                context = context as LocalContext ?? throw new InvalidCastException($"can't cast context {context} to LocalContext");
            }
            var migrator = context.Database.GetService<IMigrator>();
            var pendingMigrations = context.GetPendingMigrationScripts().Select(s => s.Replace("\r\nGO", " "))
                                                                        .ToList();
            if (pendingMigrations.Any())
            {                
                pendingMigrations.ForEach(migration => {
                    try
                    {
                        context.Database.ExecuteSqlRaw(migration);
                    }catch(Exception ex)
                    {
                        //TODO:Log exception

                    }
                });
            }
        }
        public static IEnumerable<string> GetPendingMigrationScripts(this BaseContext context)
        {
            if (context is RemoteContext)
            {
                context = context as RemoteContext ?? throw new InvalidCastException($"can't cast context {context} to RemoteContext");
                //if(context is null)
            }
            if (context is LocalContext)
            {
                context = context as LocalContext ?? throw new InvalidCastException($"can't cast context {context} to LocalContext");
            }
            var migrator = context.Database.GetService<IMigrator>();
            //If you don't do this, ef will try to execute migration from another context
            var pendingMigrations = context.Database.GetPendingMigrations().Where(m => m.Contains(context.Database.ProviderName.ToLower())).ToList();          
            var scriptsEnum = pendingMigrations.GetEnumerator();
            var idempotent = !context.Database.IsSqlite();
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
            var connection = context.Database.GetDbConnection();
            var _dbname = string.IsNullOrEmpty(dbName) ? connection.Database : dbName;
            var _backupFileName = string.IsNullOrEmpty(backupFileName) ? _dbname : backupFileName;
            string backupScript = $@"BACKUP DATABASE {_dbname} to DISK=N'{_backupFileName}.bak' WITH FORMAT, INIT, STATS=10;";
            context.Database.ExecuteSqlRaw(backupScript);
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
            context.Database.ExecuteSqlRaw($@"  USE master;
                                                ALTER DATABASE {_dbname}
                                                SET SINGLE_USER                                                
                                                WITH ROLLBACK IMMEDIATE
                                                RESTORE DATABASE {_dbname} FROM DISK = '{backupFileName}.bak' WITH REPLACE");
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
