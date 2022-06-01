using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Identity;
using Infrastructure.Interfaces.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class DefaultIdentityService : IUserIdentityService
    {        
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        public DefaultIdentityService(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        RoleManager<AppRole> roleManager)
        {            
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<BaseResult<AppUser>> CreateUserAsync(AppUser appUser, string password)
        {
            var user = await _userManager.FindByNameAsync(appUser.UserName);
            if(user != null)
                return BaseResult.Succeed("",user);
                        
            var r = await _userManager.CreateAsync(appUser,password);            
            if(!r.Succeeded){
                var userCreationErrors = r.Errors
                    .Select(e => $"Code:{e.Code} - Description:{e.Description}")
                    .ToArray();
                return BaseResult<AppUser>.Failed(userCreationErrors,appUser);
                //TODO:
            }
            var resultRoleCreation = await _userManager.AddToRoleAsync(appUser,"Admin");
            var roleCreationErrors = resultRoleCreation.Errors
                    .Select(e => $"Code:{e.Code} - Description:{e.Description}")
                    .ToArray();
            return !resultRoleCreation.Succeeded
                ? BaseResult<AppUser>.Failed(roleCreationErrors,appUser)
                : BaseResult<AppUser>.Succeed("User created with success",appUser);
        }

        public Task<AppUser> GetUserByNameAsync(string username)
        {            
            return _userManager.FindByNameAsync(username);
        }

        public async Task<IList<string>> GetUserRoleAsync(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            var userRoles = await _userManager.GetRolesAsync(appUser);
            return userRoles;
        }

        public Task<bool> IsAnExistingUserAsync(string userName)
        {
            return _userManager.Users.AnyAsync(u => u.UserName == userName);
        }

        public async Task<bool> IsValidUserCredentialsAsync(string userName, string password)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            if(appUser is null)
              return false;
            var checkResult = await _signInManager.CheckPasswordSignInAsync(appUser,password,lockoutOnFailure:false);            
            return checkResult.Succeeded;
        }
    }
}
