using System;
using System.Threading.Tasks;
using Infrastructure.Interfaces.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Identity
{    
    public class AppRole : IdentityRole<Guid>
    {        
        
        public AppRole()
        {            
        }   
        public AppRole(string roleName) : base(roleName)
        {            
        }
        public override Guid Id { get; set; } = Guid.NewGuid();
        public const string Admin = nameof(Admin);
        public const string BasicUser = nameof(BasicUser);      
    }
}