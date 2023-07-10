using IdentityModel.Client;
using IdentityServer4.Repository.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace IdentityServer4.Client.HttpClients
{
    public class HttpClientKullaniciApi: ClientCredentials
    {
        private readonly HttpClient _httpClient;
        public HttpClientKullaniciApi(HttpClient http):base(http)
        {
            _httpClient = http;
        }

        public async Task<ResponseDto<NoContentDto>> KullaniciKayitOl(KullaniciKayitOlDto KullaniciKayitOlDto)
        {
            TokenResponse tokenResponse =await ClientCredentialsRequest();
            if (tokenResponse.IsError)
            {
                //hata varsa
                return ResponseDto<NoContentDto>.UnSuccessFul(404, tokenResponse.ErrorDescription!);
            }
            _httpClient.SetBearerToken(tokenResponse.AccessToken!);

           HttpResponseMessage httpResponseMessage=  await _httpClient.PostAsJsonAsync<KullaniciKayitOlDto>("Kullanici/NewKullaniciEkle",KullaniciKayitOlDto);
            return httpResponseMessage.IsSuccessStatusCode ? await httpResponseMessage.Content.ReadFromJsonAsync<ResponseDto<NoContentDto>>() : ResponseDto<NoContentDto>.UnSuccessFul(200,"fail");
            
        }

        public async Task<ResponseDto<(ClaimsPrincipal,AuthenticationProperties)>> KullaniciGiris(KullaniciGirisDto kullaniciGirisDto)
        {
            TokenResponse tokenResponse=await ClientCredentialsRequest();
            if(tokenResponse.IsError)
            {
                //hata varsa
                return ResponseDto<(ClaimsPrincipal,AuthenticationProperties)>.UnSuccessFul(404,"errors");
            }
            _httpClient.SetBearerToken(tokenResponse.AccessToken!);

          var disco= await _httpClient.GetDiscoveryDocumentAsync("https://localhost:7291");


            PasswordTokenRequest passwordTokenRequest= new PasswordTokenRequest();
            passwordTokenRequest.Password = kullaniciGirisDto.KullaniciSifre;
            passwordTokenRequest.UserName = kullaniciGirisDto.KullaniciName;
            passwordTokenRequest.Address = disco.TokenEndpoint;
            passwordTokenRequest.ClientId = "Client1-ResourceOwner";
            passwordTokenRequest.ClientSecret = "secrets";

            var PasswordtokenResponse=  await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);
            if(PasswordtokenResponse.IsError)
            {
                //kullanıcıadı veya şifre yanlış
                return ResponseDto<(ClaimsPrincipal, AuthenticationProperties)>.UnSuccessFul(200, "kullanıcı adı veya şifre yanlış");
            }

            var jwtHander = new JwtSecurityTokenHandler();
            var token= jwtHander.ReadJwtToken(PasswordtokenResponse.AccessToken);



     
            var ClaimPrincipal = new ClaimsPrincipal(new List<ClaimsIdentity>() { new ClaimsIdentity(token.Claims.Where(x => x.Type == "claim1" || x.Type == "claim2").ToList(), CookieAuthenticationDefaults.AuthenticationScheme)});

            var authenticationProperties = new AuthenticationProperties();
            authenticationProperties.StoreTokens(new List<AuthenticationToken>(){
                new AuthenticationToken()
                {
                    Name="accesstoken",
                    Value=PasswordtokenResponse.AccessToken
                },
                new AuthenticationToken()
                {
                    Name="refreshtoken",
                    Value=PasswordtokenResponse.RefreshToken
                },
                new AuthenticationToken()
                {
                    Name="TokenSuresi",
                    Value=DateTime.UtcNow.AddSeconds(PasswordtokenResponse.ExpiresIn).ToString("o",CultureInfo.InvariantCulture)
                },
            });






            HttpResponseMessage httpResponseMessage= await _httpClient.PostAsJsonAsync("Kullanici/KullaniciSorgula", kullaniciGirisDto);
            if(httpResponseMessage.IsSuccessStatusCode)
            {
                return ResponseDto<(ClaimsPrincipal,AuthenticationProperties)>.Success((ClaimPrincipal,authenticationProperties),200);
            }
            return ResponseDto<(ClaimsPrincipal,AuthenticationProperties)>.UnSuccessFul(200,"fail");

        }
    }
}
