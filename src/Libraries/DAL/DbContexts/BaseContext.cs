using Core.Entities;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Entities.Legacy;
using Core.Entities.Stock;
using Core.Entities.Sync;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public override int SaveChanges()
        {
            var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).LastUpdatedOn = DateTimeOffset.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTimeOffset.Now;
                }
            }

            return base.SaveChanges();
        }
        #region Untested/Not implemented
        //Need to think better about how to implement this
        public virtual Task<int> SyncContextWithRemoteAsync(RemoteContext remoteContext)
        {
            var unsyncedEntries = GetUnsyncedEntitiesEntries();
            throw new NotImplementedException();
        }
        public virtual IEnumerable<object> GetUnsyncedEntitiesEntries()
        {            
            Type classRef = typeof(BaseContext);
            MethodInfo mi = classRef.GetMethod("GetUnsyncedEntities", BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var entityType in this.Model.GetEntityTypes())
            {                
                MethodInfo miConstructed = mi.MakeGenericMethod(entityType.ClrType);
                var entities = miConstructed.Invoke(this, new object[] { DateTimeOffset.UtcNow }) as IEnumerable<object>;
                if (entities is null) 
                    throw new Exception($"can't retrieve collection of unsynced {entityType.Name} entities, cast to IEnumerable<object> fails");
                yield return entities;
            }
        }
        public virtual IEnumerable<object> GetUnsyncedAddedEntities<T>() where T : BaseEntity
        {
            var lastSync = this.Set<Syncronization>().Where(s => s.Id == this.Set<Syncronization>().Count())
                                                   .FirstOrDefault();
            var lastSyncDate = lastSync.LastUpdatedOn;
            return this.Set<T>()
                .AsQueryable()
                .Where(e => e.CreatedAt > lastSyncDate || e.LastUpdatedOn > lastSyncDate);
        }
        #endregion
    }
}
