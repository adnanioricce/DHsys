using System;
using System.Threading.Tasks;
using Infrastructure.Interfaces.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Identity
{    
    public class AppUser : IdentityUser<Guid>
    {        
        public AppUser()
        {
            Id = Guid.NewGuid();
        }
        
        public static async Task<AppUser> GetAdminAsync(
            Func<string,Task<AppUser>> getUserByUsernameAsync,
            Func<AppUser,string,Task<IdentityResult>> createUserAsync,
            Func<AppUser,string,Task<IdentityResult>> addRoleAsync){
            var user = await getUserByUsernameAsync("Admin");
            if(user != null)
                return user;

            user = new AppUser{
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                Email = "admin@email.com",
            };            
            await createUserAsync(user,"password");            
            await addRoleAsync(user,"Admin");            
            return user;
        }
        public static async Task<AppUser> GetAdminAsync(UserManager<AppUser> userManager)
        {
            var user = await userManager.FindByNameAsync("Admin");
            if(user != null)
                return user;

            user = new AppUser{
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                Email = "admin@email.com"                
            };            
            var r = await userManager.CreateAsync(user,"@P4ssword");
            if(!r.Succeeded){
                //TODO:
            }
            await userManager.AddToRoleAsync(user,"Admin");   
            return user;
            // var user = await AppUser.GetAdminAsync(userManager.FindByNameAsync,
            //     async (appUser,password) => {
            //         var result = await userManager.CreateAsync(appUser,password);                    
            //         return appUser;
            //     },
            //     async (appUser,role) => {
            //         var result = await userManager.AddToRoleAsync(appUser,role);
            //         return appUser;
            //     });
            // return user;
        }
        public static async Task<AppUser> GetAdminAsync(IServiceProvider ServiceProvider){
            var userIdentityService = ServiceProvider.GetRequiredService<IUserIdentityService>();            
            var userManager = ServiceProvider.GetRequiredService<UserManager<AppUser>>();                        
            return await GetAdminAsync(userManager);
        }
    }
}