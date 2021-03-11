using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Users
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthTestController : ControllerBase
    {
        [HttpGet("test")]
        [Authorize("Default")]
        public async Task<IActionResult> Get()
        {   
            return Ok("Secured");
        }
    }
}