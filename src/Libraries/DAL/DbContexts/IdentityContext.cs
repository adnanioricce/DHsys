using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbContexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options){            }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
                        
        }
    }
}