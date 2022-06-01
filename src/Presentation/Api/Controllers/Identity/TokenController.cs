using Infrastructure.Identity;
using Infrastructure.Interfaces.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Api.Controllers.Identity.Models;
using System.Net.Mail;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api.Controllers.Identity
{           
    [Route("api/[Controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {        
        private readonly IWebHostEnvironment _environment;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly IUserIdentityService _userService;
        public TokenController(IWebHostEnvironment environment,
        IJwtAuthManager jwtAuthManager,
        IUserIdentityService userIdentityService)
        {            
            _environment = environment;
            _jwtAuthManager = jwtAuthManager;
            _userService = userIdentityService;
        }
        // public async Task<IActionResult> GetAccessToken()
        // {
        //     //TODO: Not Implemented           
        //     throw new NotImplementedException(); 
        //     if (!_environment.IsDevelopment())
        //         return StatusCode(500,new { Message = "Endpoint not available" });                        
        // }
        bool IsValidEmail(string email){
            try
            {
                var m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult> Signup([FromBody]SignupRequest request){
            var user = await _userService.GetUserByNameAsync(request.Username);
            if(user != null){
                return BadRequest(new {
                    Errors = new [] {"Username already taken"}
                });            
            }            
            var email = IsValidEmail(request.Username) 
                ? request.Username
                : null;
            var appUser = new AppUser{
              UserName = request.Username,
              Email = email
            };
            var userCreationResult = await _userService.CreateUserAsync(appUser,request.Password);
            if(!userCreationResult.Success){
                //TODO: Edit BaseResult to distinct errors that can and cannot be show to the user.
                return BadRequest(new {
                    Errors = userCreationResult.Errors.ToArray()
                });
            }
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {
                    Errors = ModelState.Values.Select(v => v.Errors).ToArray()
                });
            }

            if (!await _userService.IsValidUserCredentialsAsync(request.UserName, request.Password))
            {
                return Unauthorized();
            }

            var roles = await _userService.GetUserRoleAsync(request.UserName);
            var rolesClaims = roles.Select(r => new Claim(ClaimTypes.Role,r));
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.UserName)                
            }.Concat(rolesClaims)
            .ToArray();

            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            // //_logger.LogInformation($"User [{request.UserName}] logged in the system.");
            return Ok(new LoginResult
            {
                UserName = request.UserName,
                Roles = roles.ToList(),
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
        [HttpPost("refresh-token")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var userName = User.Identity?.Name;
                //_logger.LogInformation($"User [{userName}] is trying to refresh JWT token.");

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);
                //_logger.LogInformation($"User [{userName}] has refreshed JWT token.");
                return Ok(new LoginResult
                {
                    UserName = userName,
                    Roles = User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList(),
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            catch (SecurityTokenException e)
            {
                return Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
            }
        }

        [HttpPost("impersonation")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<ActionResult> Impersonate([FromBody] ImpersonationRequest request)
        {
            var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is trying to impersonate [{request.UserName}].");

            var impersonatedRoles = await _userService.GetUserRoleAsync(request.UserName);
            var rolesClaims = impersonatedRoles.Select(r => new Claim(ClaimTypes.Role,r));
            if (!impersonatedRoles.Any())
            {
                //_logger.LogInformation($"User [{userName}] failed to impersonate [{request.UserName}] due to the target user not found.");
                return BadRequest($"The target user [{request.UserName}] is not found.");
            }
            if (impersonatedRoles.Contains(AppRole.Admin))
            {
                //_logger.LogInformation($"User [{userName}] is not allowed to impersonate another Admin.");
                return BadRequest("This action is not supported.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.UserName),                
                new Claim("OriginalUserName", userName ?? string.Empty)
            }.Concat(rolesClaims)
            .ToArray();

            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            //_logger.LogInformation($"User [{request.UserName}] is impersonating [{request.UserName}] in the system.");
            return Ok(new LoginResult
            {
                UserName = request.UserName,
                Roles = impersonatedRoles.ToList(),
                OriginalUserName = userName,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [HttpPost("stop-impersonation")]
        public async Task<ActionResult> StopImpersonation()
        {
            var userName = User.Identity?.Name;
            var originalUserName = User.FindFirst("OriginalUserName")?.Value;
            if (string.IsNullOrWhiteSpace(originalUserName))
            {
                return BadRequest("You are not impersonating anyone.");
            }
            //_logger.LogInformation($"User [{originalUserName}] is trying to stop impersonate [{userName}].");

            var roles = await _userService.GetUserRoleAsync(originalUserName);
            var rolesClaims = roles.Select(r => new Claim(ClaimTypes.Role,r));
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,originalUserName),                
            }.Concat(rolesClaims).ToArray();

            var jwtResult = _jwtAuthManager.GenerateTokens(originalUserName, claims, DateTime.Now);
            //_logger.LogInformation($"User [{originalUserName}] has stopped impersonation.");
            return Ok(new LoginResult
            {
                UserName = originalUserName,
                Roles = roles.ToList(),
                OriginalUserName = null,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
    }
}
