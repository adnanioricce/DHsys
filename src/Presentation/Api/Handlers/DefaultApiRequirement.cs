using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Api.Handlers
{
    // public class DefaultApiRequirement : AuthorizationHandler<DefaultApiRequirement>, IAuthorizationRequirement
    // {
    //     protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DefaultApiRequirement requirement)
    //     {
    //         // if(!context.User.HasClaim(c => c.Type == "scope")){
    //         //     return Task.CompletedTask;
    //         // }
    //         // if(context.User.HasClaim(c => c.Type))
    //     }
    // }
}