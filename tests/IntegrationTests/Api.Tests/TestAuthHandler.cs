using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api.Tests.Handlers
{
    public class TestAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {    
        public TestAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, 
                            ILoggerFactory logger, 
                            UrlEncoder encoder, 
                            ISystemClock clock)
                : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new[] { 
                new Claim(ClaimTypes.Name, "alice"),
                new Claim(ClaimTypes.Email,"user@email.com")                
            };
            var identity = new ClaimsIdentity(claims, "Test");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "Test");

            var result = AuthenticateResult.Success(ticket);

            return Task.FromResult(result);
        }
    }
}