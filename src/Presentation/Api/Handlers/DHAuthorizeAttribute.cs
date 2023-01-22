using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Handlers
{
    public class DHAuthorizeAttribute : AuthorizeAttribute
    {
        
        public async Task OnAuthorizationAsync(AuthorizationFilterContext authorizationFilterContext)
        {
            var token = await authorizationFilterContext.HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme);
            if (authorizationFilterContext.HttpContext.User.Identity.IsAuthenticated == false)
            {
                       
                // base.Function();
            }            
        }
    }
}