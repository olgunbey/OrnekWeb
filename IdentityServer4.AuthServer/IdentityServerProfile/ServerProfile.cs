using IdentityModel;
using IdentityServer4.Client.HttpClients;
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
        private readonly HttpClientKullaniciApi _httpClientKullaniciApi;
        public ServerProfile(HttpClientKullaniciApi httpClientKullaniciApi)
        {
            _httpClientKullaniciApi = httpClientKullaniciApi;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            
           var Kullanicilar=  await  _httpClientKullaniciApi.KullaniciSorgula(new Repository.Dtos.KullaniciGirisDto() { KullaniciName=context.UserName,KullaniciSifre=context.Password});
            
            if (Kullanicilar.Data != null)
            {
                context.Result = new GrantValidationResult(Kullanicilar.Data.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }
        }
    }
}
