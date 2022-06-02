using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Handlers
{
    public class DHAuthorizeAttribute : AuthorizeAttribute
    {
        
        public async Task OnAuthorizationAsync(AuthorizationFilterContext authorizationFilterContext)
        {
            if (authorizationFilterContext.HttpContext.User.Identity.IsAuthenticated == false)
            {
                // base.Function();
            }
        }
    }
}