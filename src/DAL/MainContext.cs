using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class MainContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }
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
            });
        }
    }
}
