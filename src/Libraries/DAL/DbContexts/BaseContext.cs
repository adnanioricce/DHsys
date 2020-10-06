using Core.Entities;
using Core.Entities.Sync;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.DbContexts
{
    public class BaseContext : DbContext
    {        
        public BaseContext(DbContextOptions<BaseContext> options)
        : base(options)
        {            
        }
        protected BaseContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }
        protected void PrepareEntities()
        {
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).LastUpdatedOn = DateTimeOffset.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTimeOffset.UtcNow;
                }
            }

        }
        public override int SaveChanges()
        {
            PrepareEntities();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            PrepareEntities();
            return base.SaveChangesAsync(cancellationToken);
        }
        #region Untested/Not implemented
        //Need to think better about how to implement this
        public virtual Task<int> SyncContextWithRemoteAsync(RemoteContext remoteContext)
        {
            var unsyncedEntries = GetUnsyncedEntitiesEntries();
            remoteContext.AddRange(unsyncedEntries);
            return remoteContext.SaveChangesAsync();
        }        
        public virtual async IAsyncEnumerable<List<BaseEntity>> GetUnsyncedEntitiesEntries()
        {            
            Type classRef = typeof(BaseContext);
            MethodInfo mi = classRef.GetMethod("GetUnsyncedEntities", BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var entityType in this.Model.GetEntityTypes())
            {                
                MethodInfo miConstructed = mi.MakeGenericMethod(entityType.ClrType);
                dynamic task = miConstructed.Invoke(this,null) as List<BaseEntity>;
                await task;
                var entities = task.GetAwaiter().GetResult(); 
                if (entities is null) 
                    throw new Exception($"can't retrieve collection of unsynced {entityType.Name} entities, cast to IEnumerable<object> fails");
                yield return (List<BaseEntity>)entities;
            }
        }
        public virtual Task<List<T>> GetUnsyncedAddedEntities<T>() where T : BaseEntity
        {
            var lastSync = this.Set<Syncronization>().Last();                        
            var lastSyncDate = lastSync.LastUpdatedOn;
            return this.Set<T>()
                .AsQueryable()
                .Where(e => e.CreatedAt > lastSyncDate || e.LastUpdatedOn > lastSyncDate)
                .ToListAsync();
        }
        #endregion
    }
}