using IdentityModel.Client;
using IdentityServer4.Repository.Dtos;
using System.Reflection.Metadata.Ecma335;

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

        public async Task<ResponseDto<KullaniciDto>> KullaniciGiris(KullaniciGirisDto kullaniciGirisDto)
        {
            TokenResponse tokenResponse=await ClientCredentialsRequest();
            if(tokenResponse.IsError)
            {
                //hata varsa
                return ResponseDto<KullaniciDto>.UnSuccessFul(404,tokenResponse.ErrorDescription!);
            }
            _httpClient.SetBearerToken(tokenResponse.AccessToken!);

            HttpResponseMessage httpResponseMessage= await _httpClient.PostAsJsonAsync("Kullanici/KullaniciSorgula", kullaniciGirisDto);
            return httpResponseMessage.IsSuccessStatusCode ? await httpResponseMessage.Content.ReadFromJsonAsync<ResponseDto<KullaniciDto>>() : ResponseDto<KullaniciDto>.UnSuccessFul(200, "fail");
        }
    }
}
