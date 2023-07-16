using IdentityServer4.Client.HttpClients;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace IdentityServer4.Client.Middlewares
{
    public class Middleware1
    {
        RequestDelegate _next;
        HttpClientKullaniciApi _httpClientKullaniciApi;

        public Middleware1(RequestDelegate requestDelegate, HttpClientKullaniciApi httpClientKullaniciApi)
        {
            _next = requestDelegate;
            _httpClientKullaniciApi = httpClientKullaniciApi;


        }
        public async Task Invoke(HttpContext httpContext)
        {
            var Claims = httpContext.User.Claims.ToList();

            if(Claims.Count>0)
            {
                Claim? claim = Claims.FirstOrDefault(x => x.Type == "sub");
                var ResponseDto = await _httpClientKullaniciApi.KullaniciRole(Convert.ToInt32(claim.Value));
                bool kontrol = true;
                Claims.Remove(claim);
                foreach (var Kullaniciclaim in Claims)
                {
                    foreach (var KullaniciDbRole in ResponseDto.Data)
                    {
                        if (Kullaniciclaim.Value == KullaniciDbRole.RoleName)
                        {
                            kontrol = true;
                        }
                        else
                        {
                            kontrol = false;
                        }
                    }
                }
                if (!kontrol)
                {
                    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
            }
         
            await _next.Invoke(httpContext);
           


        }
    }
}
