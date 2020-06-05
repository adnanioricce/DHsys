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
            var migrator = context.Database.GetService<IMigrator>();
            var pendingMigrations = context.GetPendingMigrationScripts().Select(s => s.Replace("\r\nGO", " "))
                                                                        .ToList();
            if (pendingMigrations.Any())
            {                
                pendingMigrations.ForEach(migration => context.Database.ExecuteSqlRaw(migration));
            }
        }
        public static IEnumerable<string> GetPendingMigrationScripts(this BaseContext context)
        {
            var migrator = context.Database.GetService<IMigrator>();
            var pendingMigrations = context.Database.GetPendingMigrations().ToList();            
            var scriptsEnum = pendingMigrations.GetEnumerator();
            var idempotent = !context.Database.IsSqlite() ? true : false;
            var scripts = pendingMigrations.Select(m => migrator.GenerateScript(toMigration:m,idempotent:idempotent));
            return scripts;
        }        
    }
}
