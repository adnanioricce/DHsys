// using System;
// using System.Linq;
// using System.Security.Claims;
// using System.Threading.Tasks;
// using Api.Controllers.Authentication.Models;
// using Api.Controllers.Users.Models;
// using DAL.Identity;
// using Microsoft.AspNetCore;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using OpenIddict.Abstractions;
// using OpenIddict.Server.AspNetCore;
// using static OpenIddict.Abstractions.OpenIddictConstants;
// namespace Api.Controllers.Users
// {
//     [Route("account")]
//     [ApiController]
//     public class AccountController : Controller
//     {
//         protected readonly SignInManager<AppUser> _signInManager;
//         protected readonly UserManager<AppUser> _userManager;        
//         protected readonly IOpenIddictApplicationManager _applicationManager;

//         public AccountController(SignInManager<AppUser> signInManager,
//             UserManager<AppUser> userManager,            
//             IOpenIddictApplicationManager applicationManager)
//         {
//             _signInManager = signInManager;
//             _userManager = userManager;            
//             _applicationManager = applicationManager;
//         }
//         [HttpPost("signup")]
//         public async Task<ActionResult> SignUp([FromBody]SignUpRequest request)
//         {
//             // var serverRequest = HttpContext.GetOpenIddictServerRequest();
//             var appUser = request.MapToAppUser(_userManager);
//             var result = await _userManager.CreateAsync(appUser);
//             if(result.Succeeded){
//                 return Ok(result);
//             }
//             return StatusCode(500,result);
//             // var identity = new ClaimsIdentity(TokenValidationParameters.DefaultAuthenticationType,Claims.Name, Claims.Role);
//             // var principal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal;
//             // return SignIn(principal,OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
//         }
//         [HttpPost("~/connect/token"),Produces("application/json")]
//         public async Task<IActionResult> Exchange([FromBody]OpenIddictRequest request)
//         {            
//              if(request.IsPasswordGrantType()){
//                 var user = await _userManager.FindByNameAsync(request.Username);
//                 var result = await _signInManager.PasswordSignInAsync(user,request.Password,isPersistent:false,lockoutOnFailure:false);
//                 if(!result.Succeeded){
//                     return BadRequest();
//                 }
//                 var principal = await _signInManager.CreateUserPrincipalAsync(user);
//                 // var identity = new ClaimsIdentity(TokenValidationParameters.DefaultAuthenticationType,Claims.Name,Claims.Role);
//                 if (string.IsNullOrEmpty(principal.FindFirstValue(Claims.Subject))){
//                     // principal.Claims
//                     // identity.AddClaim(Claims.Subject, await _userManager.GetUserIdAsync(user), Destinations.AccessToken);
//                     principal.SetClaim(Claims.Subject,await _userManager.GetUserIdAsync(user));                    
//                 }
//                 principal.SetScopes(new[]
//                 {
//                     Scopes.OpenId,
//                     Scopes.Email,
//                     Scopes.Profile,
//                     Scopes.OfflineAccess,
//                     Scopes.Roles
//                 }.Intersect(request.GetScopes()));
//                 foreach(var claim in principal.Claims){
                    
//                     claim.SetDestinations(Destinations.AccessToken,Destinations.IdentityToken);
//                 }
//                 // principal.SetResources("api");
//                 // identity.AddClaim(Claims.Name, user.UserName, Destinations.AccessToken);                
                
//                 // identity.AddClaim
//                 // identity.AddClaim(Claims.Name, await _applicationManager.GetDisplayNameAsync(application),
//                 //     Destinations.AccessToken, Destinations.IdentityToken);
//                 // return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
//                 try{
//                     var r = SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);                    
//                     return r;
//                 }catch(Exception ex){
//                     throw ex;
//                 }
//             }
//             return BadRequest();
//         }
//     }
// }