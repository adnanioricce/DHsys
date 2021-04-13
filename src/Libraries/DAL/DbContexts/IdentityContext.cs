using DAL.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DAL.DbContexts
{
    public class IdentityContext : ApiAuthorizationDbContext<AppUser>
    {
        
        public IdentityContext(DbContextOptions<IdentityContext> options,IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options,operationalStoreOptions){            }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}