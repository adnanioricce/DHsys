using System.Threading.Tasks;
using Api.Controllers.Users.Models;
using DAL.Identity;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static IdentityServer4.IdentityServerConstants;

namespace Api.Controllers.Users
{
    [Route("users")]
    [ApiController]
    public class UsersControllers : Controller
    {
        protected readonly SignInManager<AppUser> _signInManager;
        protected readonly UserManager<AppUser> _userManager;                

        public UsersControllers(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }        
        [HttpPost("operator/signup")]            
        public async Task<ActionResult> RegisterOperator([FromBody]SignUpRequest request)
        {
            // LocalApi.
            var appUser = request.MapToAppUser(_userManager);
            var result = await _userManager.CreateAsync(appUser);
            if(!result.Succeeded){
                AppLogger.Log.Information("failed to create operator @operatorName. Error messages:@errors",appUser.UserName,result.Errors);
                return StatusCode(500,result);                
            }            
            await _userManager.AddClaimAsync(appUser, new System.Security.Claims.Claim("scope","operator"));
            return Ok("User created!");
        }        
    }
}