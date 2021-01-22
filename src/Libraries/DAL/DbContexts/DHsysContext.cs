using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.DbContexts
{
    public class DHsysContext : DbContext
    {        
        public DHsysContext(DbContextOptions<DHsysContext> options)
        : base(options)
        {            
        }
        protected DHsysContext(DbContextOptions options) : base(options)
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
                    ((BaseEntity)entityEntry.Entity).UniqueCode = Guid.NewGuid().ToString();
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
    }
}