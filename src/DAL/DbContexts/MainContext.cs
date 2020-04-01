using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class MainContext : DbContext
    {
        //public DbSet<Conta> Contas { get; set; }
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./database.db");            
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
        }
    }
}
