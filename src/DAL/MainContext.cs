using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class MainContext : DbContext
    {
        //public DbSet<Conta> Contas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./contas.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>(mapper =>
            {
                mapper.ToTable("Contas");
                mapper.HasKey(prop => prop.Id);
                mapper.HasData(new[] { 
                    new Conta
                    {
                        Id = 1,
                        DataDeVencimento = DateTime.UtcNow.ToString(),
                        NomeEmpresa = "empresa",
                        Valor = 12.99m
                    }, new Conta
                    {
                        Id = 2,
                        DataDeVencimento = DateTime.UtcNow.ToString(),
                        NomeEmpresa = "empresa 2",
                        Valor = 22.99m
                    }
                });
            });
        }
    }
}
