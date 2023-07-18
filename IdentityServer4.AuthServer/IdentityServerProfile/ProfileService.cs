using IdentityServer4.Client.HttpClients;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using IdentityServer4.Services;
using System.Security.Claims;

namespace IdentityServer4.AuthServer.IdentityServerProfile
{
    public class ProfileService : IProfileService //burada api ile bağlanılacak
    {
        private readonly UyelerIReadBusiness _uyelerIReadBusiness;

        private readonly HttpClientRoleApi _httpClientRoleApi;
        public ProfileService(UyelerIReadBusiness uyelerIReadBusiness,HttpClientRoleApi httpClientRoleApi)
        {
            _uyelerIReadBusiness = uyelerIReadBusiness;
            _httpClientRoleApi = httpClientRoleApi;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userClaims = context.RequestedResources.Resources.IdentityResources.SelectMany(r => r.UserClaims).ToList();//buradan erişilir

          var ResponseDto= await _httpClientRoleApi.KullaniciRollerGetirApi(Convert.ToInt16(context.Subject.GetSubjectId()));

            //var ResponseDto =await _uyelerIReadBusiness.KullaniciRoleGetir(Convert.ToInt32(context.Subject.GetSubjectId())); //kullanıcının rolleri gelecek //db'ten çekiyor rolleri
            ResponseDto.Data.ForEach(x =>
            {
                string? claimRole= userClaims.FirstOrDefault(x => x == ClaimTypes.Role);
                
                context.IssuedClaims.AddRange(GeneratedClaim(claimRole!, x.RoleName).ToList());
            });
            string? claimSub = userClaims.FirstOrDefault(x => x == "sub");
            context.IssuedClaims.AddRange(GeneratedClaim(claimSub,context.Subject.GetSubjectId()));
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
