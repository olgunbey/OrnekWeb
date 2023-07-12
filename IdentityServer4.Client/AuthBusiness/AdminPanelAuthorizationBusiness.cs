using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace IdentityServer4.Client.AuthBusiness
{
    public class AdminPanelAuthorizationBusiness:IAuthorizationRequirement
    {
    }
    public class AdminPanelAuthorizationHandler : AuthorizationHandler<AdminPanelAuthorizationBusiness>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminPanelAuthorizationBusiness requirement)
        {
          Claim? adminRoleClaim=  context.User.Claims.FirstOrDefault(opt=>opt.Type==ClaimTypes.Role); //sadece role claimini çağırıyoruz

            if(adminRoleClaim.Value=="Admin")
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            context.Fail();
            return Task.CompletedTask;
                
        }
    }
}
