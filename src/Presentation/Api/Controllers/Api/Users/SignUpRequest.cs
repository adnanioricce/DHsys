using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DAL.Identity;
using Microsoft.AspNetCore.Identity;

namespace Api.Controllers.Users.Models
{
    
    public class SignUpRequest
    {                
        [StringLength(255)]        
        public string UserName  { get; set; }        
        [StringLength(255)]
        public string Password { get; set; }                
        public AppUser MapToAppUser(UserManager<AppUser> userManager)
        {
            var appUser = new AppUser{
              UserName = UserName             
            };
            appUser.PasswordHash = userManager.PasswordHasher.HashPassword(appUser,this.Password);
            return appUser;
        }
    }
}