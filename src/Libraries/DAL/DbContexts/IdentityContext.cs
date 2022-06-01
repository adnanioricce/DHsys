

using System;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DAL.DbContexts
{
    public class IdentityContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options){}
        Guid ToGuid(string value){
           if(Guid.TryParse(value,out var r)){
                return r;
           }
           return Guid.Empty;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>(mapper => {
                mapper.Property(entity => entity.Id)
                    .HasConversion(p => p.ToString(),v => ToGuid(v));
            });
            builder.Entity<AppRole>(mapper => {
                mapper.Property(entity => entity.Id)
                    .HasConversion(p => p.ToString(),v => ToGuid(v));
            });
            base.OnModelCreating(builder);
        }
    }
}
