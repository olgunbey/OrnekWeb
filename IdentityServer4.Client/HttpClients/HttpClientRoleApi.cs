using IdentityModel.Client;
using IdentityServer4.Repository.Dtos;
using System.Runtime.CompilerServices;

namespace IdentityServer4.Client.HttpClients
{
    public class HttpClientRoleApi : ClientCredentials
    {
        public HttpClientRoleApi(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<ResponseDto<List<RollerDto>>> RoleListeleApi()
        {
            TokenResponse tokenResponse = await ClientCredentialsRequest();
            if (tokenResponse.IsError)
            {
                //hata varsa
                return ResponseDto<List<RollerDto>>.UnSuccessFul(200, "401-403 unauthorized");
            }
            _httpClient.SetBearerToken(tokenResponse.AccessToken!);
          return await _httpClient.GetFromJsonAsync<ResponseDto<List<RollerDto>>>("Kullanici/RoleListele");

        }

        public async Task<ResponseDto<string>> KullaniciRoleEkleApi(int kullaniciId,string roleName)
        {
            TokenResponse tokenResponse = await ClientCredentialsRequest();
            if(tokenResponse.IsError)
            {
                //hata varsa
                return ResponseDto<string>.UnSuccessFul(401,"401-403 unauthorized");
            }
            _httpClient.SetBearerToken(tokenResponse.AccessToken!);

          return await  _httpClient.GetFromJsonAsync<ResponseDto<string>>($"Kullanici/KullaniciRoleEkle/{kullaniciId}/{roleName}");

        }
    }
}
