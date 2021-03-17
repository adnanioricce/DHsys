using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Users
{
    [Route("api/[Controller]")]
    [ApiController]        
    
    public class AuthTestController : ControllerBase
    {
        public AuthTestController()
        {
            
        }        
        [HttpGet("test")]
        [Authorize(policy:"Default",AuthenticationSchemes = IdentityServerConstants.LocalApi.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {
            return new JsonResult(HttpContext.User.Claims.Select(c => new {c.Type,c.Value}).ToList());
        }
    }
}