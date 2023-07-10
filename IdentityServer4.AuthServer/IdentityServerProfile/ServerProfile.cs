using IdentityModel;
using IdentityServer4.Domain.Entities;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using System.Security.Claims;

namespace IdentityServer4.AuthServer.IdentityServerProfile
{
    public class ServerProfile : IResourceOwnerPasswordValidator
    {
        private readonly UyelerIReadBusiness _uyelerIReadBusiness;
        public ServerProfile(UyelerIReadBusiness uyelerIReadBusiness)
        {
            _uyelerIReadBusiness = uyelerIReadBusiness;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
        Kullanicilar kullanicilar=await _uyelerIReadBusiness.GetAsync(x => x.KullaniciName == context.UserName && x.KullaniciSifre == context.Password);
            if(kullanicilar!=null)
            {
                context.Result = new GrantValidationResult(kullanicilar.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }
        }
    }
}
