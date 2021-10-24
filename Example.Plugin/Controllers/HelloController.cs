using Microsoft.AspNetCore.Mvc;

namespace Example.Plugin.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HelloController : ControllerBase
    {
        private readonly GrettingsService _greetService;
        public HelloController(GrettingsService greetService)
        {
            _greetService = greetService;
        }
        [HttpGet("greetdate")]
        public IActionResult GreetWithDate(string name)
        {
            return Ok(_greetService.GreetNameWithDate(name));
        }
        [HttpGet("greet")]
        public IActionResult Get()
        {
            return Ok("Hello!");
        }
    }
}
