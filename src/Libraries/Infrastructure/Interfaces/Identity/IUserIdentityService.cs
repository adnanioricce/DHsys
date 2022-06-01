using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Identity;

namespace Infrastructure.Interfaces.Identity
{
    public interface IUserIdentityService
    {
        Task<bool> IsAnExistingUserAsync(string userName);
        Task<bool> IsValidUserCredentialsAsync(string userName, string password);
        Task<IList<string>> GetUserRoleAsync(string userName);
        Task<AppUser> GetUserByNameAsync(string username);
        Task<BaseResult<AppUser>> CreateUserAsync(AppUser appUser, string password);
    }
}