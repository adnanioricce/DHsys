using DAL.Extensions;
using Microsoft.EntityFrameworkCore;

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
        }
    }
}
