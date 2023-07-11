using Microsoft.AspNetCore.Authorization;

namespace IdentityServer4.Client.AuthBusiness
{
    public class AuthorizationBusiness:IAuthorizationRequirement
    {
    }
    public class Authorizations : AuthorizationHandler<AuthorizationBusiness>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationBusiness requirement)
        {
            var x=  context.User.Claims.ToList();
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
