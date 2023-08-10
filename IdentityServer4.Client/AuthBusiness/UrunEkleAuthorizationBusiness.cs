using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace IdentityServer4.Client.AuthBusiness
{
    public class UrunEkleAuthorizationBusiness :IAuthorizationRequirement
    {
    }
    public class UrunEkleAuthorizationHandler : AuthorizationHandler<UrunEkleAuthorizationBusiness>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UrunEkleAuthorizationBusiness requirement)
        {
         var UserClaim= context.User.Claims.ToList();
            if(!UserClaim.Any())
            {
                context.Fail();
                return Task.CompletedTask;
            }
          var Claims= UserClaim.Where(x=>x.Type==ClaimTypes.Role && x.Value=="urunler.added").ToList();

            if(!Claims.Any())
            {
                context.Fail();
                return Task.CompletedTask;
            }
             context.Succeed(requirement);
            return Task.CompletedTask;
            
        }
    }
}
