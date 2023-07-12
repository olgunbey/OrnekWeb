using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Repository.Dtos;
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
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
           var ResponseDto=await _uyelerIReadBusiness.KullaniciRoleGetir(Convert.ToInt32(context.Subject.GetSubjectId())); //kullanıcının rolleri gelecek
            ResponseDto.Data.ForEach(x =>
            {
                var userClaims = context.RequestedResources.Resources.IdentityResources.SelectMany(r => r.UserClaims).ToList();//buradan erişilir
              string? claimRole= userClaims.FirstOrDefault(x => x == ClaimTypes.Role);
                context.IssuedClaims.AddRange(GeneratedClaim(claimRole!, x.RoleName).ToList());
            });
            



        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
        var subjectID = context.Subject.GetSubjectId();
            if (subjectID != null)
            {
                context.IsActive = true;
            }

        }
        public IEnumerable<Claim> GeneratedClaim(string type,string value)
        {
            yield return new Claim(type,value);
        }
    }
}
