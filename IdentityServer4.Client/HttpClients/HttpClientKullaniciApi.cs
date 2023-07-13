using IdentityModel;
using IdentityModel.Client;
using IdentityServer4.Repository.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace IdentityServer4.Client.HttpClients
{
    public class HttpClientKullaniciApi: ClientCredentials
    {
        public HttpClientKullaniciApi(HttpClient http):base(http)
        {
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

            
            TokenResponse? PasswordtokenResponse=  await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);
            if(PasswordtokenResponse.IsError)
            {
                //kullanıcıadı veya şifre yanlış
                return ResponseDto<(ClaimsPrincipal, AuthenticationProperties)>.UnSuccessFul(200, "kullanıcı adı veya şifre yanlış");
            }

    


            UserInfoRequest userInfoRequest= new UserInfoRequest();
            userInfoRequest.Address = disco.UserInfoEndpoint;
            userInfoRequest.Token = PasswordtokenResponse.AccessToken;
            UserInfoResponse userInfoResponse= await _httpClient.GetUserInfoAsync(userInfoRequest);

     
            var ClaimPrincipal = new ClaimsPrincipal(new List<ClaimsIdentity>() { new ClaimsIdentity(userInfoResponse.Claims, CookieAuthenticationDefaults.AuthenticationScheme)});

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






            HttpResponseMessage httpResponseMessage= await _httpClient.PostAsJsonAsync<KullaniciGirisDto>("Kullanici/KullaniciSorgula", kullaniciGirisDto);
            if(httpResponseMessage.IsSuccessStatusCode)
            {
                return ResponseDto<(ClaimsPrincipal,AuthenticationProperties)>.Success((ClaimPrincipal,authenticationProperties),200);
            }
            return ResponseDto<(ClaimsPrincipal,AuthenticationProperties)>.UnSuccessFul(200,"fail");

        }

        public async Task<ResponseDto<List<KullaniciRoleDto>>> KullaniciRole(int id)
        {
         TokenResponse tokenResponse=  await ClientCredentialsRequest();
            if(tokenResponse.IsError)
            {
                //hata varsa 
                return ResponseDto<List<KullaniciRoleDto>>.UnSuccessFul(200, "401-403 unauthorized,forbidden");
            }

            _httpClient.SetBearerToken(tokenResponse.AccessToken!);

            return await _httpClient.GetFromJsonAsync<ResponseDto<List<KullaniciRoleDto>>>($"Kullanici/KullaniciRoleGetir/{id}");



        }

        public async Task<ResponseDto<List<KullaniciRollerDto>>> KullaniciRollerGetir()
        {
            TokenResponse tokenResponse=await ClientCredentialsRequest();
            if(tokenResponse.IsError)
            {
              return ResponseDto<List<KullaniciRollerDto>>.UnSuccessFul(401, "401-403 forbidden");
            }
            _httpClient.SetBearerToken(tokenResponse.AccessToken!);

          return await _httpClient.GetFromJsonAsync<ResponseDto<List<KullaniciRollerDto>>>("Kullanici/KullanicilarRolleriGetir");
        }

        public async Task<ResponseDto<NoContentDto>> RoleCreate(RoleEkleDto roleName)
        {
            TokenResponse tokenResponse= await ClientCredentialsRequest();
            if(tokenResponse.IsError)
            {
                return ResponseDto<NoContentDto>.UnSuccessFul(401, "401-403forbidden");
            }
            _httpClient.SetBearerToken(tokenResponse.AccessToken!);

            
            HttpResponseMessage HttpResponseMessage = await _httpClient.PostAsJsonAsync("Kullanici/RoleOlustur", roleName);
            return !(HttpResponseMessage.IsSuccessStatusCode) ? ResponseDto<NoContentDto>.UnSuccessFul(404, "api bağlantı hatası") :await HttpResponseMessage.Content.ReadFromJsonAsync<ResponseDto<NoContentDto>>();
        }

    }
}
