using Core.Entities;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Entities.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace DAL
{
    public class MainContext : DbContext
    {
        //public DbSet<Conta> Contas { get; set; }
        private readonly ILoggerFactory _loggerFactory;
        public MainContext(DbContextOptions<MainContext> options,ILoggerFactory loggerFactory) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
            _loggerFactory = loggerFactory;
        }        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlite("Data Source=./database.db");            
            //TODO:Create flag to switch this between development and production. Production should not do this
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billing>(mapper =>
            {
                mapper.ToTable("Contas");
                mapper.HasKey(prop => prop.Id);
                mapper.HasData(new[] { 
                    new Billing
                    {
                        Id = 1,
                        EndDate = DateTime.UtcNow,
                        BeneficiaryName = "empresa",
                        Price = 12.99m
                    }, new Billing
                    {
                        Id = 2,
                        EndDate = DateTime.UtcNow,
                        BeneficiaryName = "empresa 2",
                        Price = 22.99m
                    }
                });
            });
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Agenda>().ToTable("Agenda");
            modelBuilder.Entity<Product>(mapper =>
            {
                mapper.ToTable("Products");
                mapper.HasMany(r => r.ProductSuppliers)
                .WithOne(ps => ps.Product)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Drug>();
            modelBuilder.Entity<StockEntry>().ToTable("StockEntries");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturers");
        }
    }
}
