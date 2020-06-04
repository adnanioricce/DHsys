using Core.Entities;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
            modelBuilder.BuildModel();
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
    }
}
