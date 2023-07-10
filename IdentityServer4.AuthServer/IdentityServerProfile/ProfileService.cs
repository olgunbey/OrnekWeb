using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using IdentityServer4.Services;
using System.Security.Claims;

namespace IdentityServer4.AuthServer.IdentityServerProfile
{
    public class ProfileService : IProfileService
    {
        private readonly UyelerIReadBusiness _uyelerIReadBusiness;
        public ProfileService(UyelerIReadBusiness uyelerIReadBusiness)
        {
            _uyelerIReadBusiness = uyelerIReadBusiness;
        }
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.Subject.GetSubjectId();

            List<Claim> claims = new List<Claim>()
            {
                new Claim("claim1","olgun1"),
                new Claim("claim2","olgun2")

            };

            context.AddRequestedClaims(claims);
            context.IssuedClaims = claims;
            return Task.CompletedTask;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
        var subjectID = context.Subject.GetSubjectId();
            context.IsActive = true;

        }
    }
}
