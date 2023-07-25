using IdentityModel.Client;
using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;

namespace IdentityServer4.Client.HttpClients
{
    public class HttpClientUrunlerApi : ClientCredentials
    {
        private readonly HttpClient httpClient;
        public HttpClientUrunlerApi(HttpClient httpClient) : base(httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<ResponseDto<List<OneChildKategoriler>>> Kategoriler()
        {
         var TokenResponse= await ClientCredentialsRequest();
            if(TokenResponse.IsError)
            {
              return ResponseDto<List<OneChildKategoriler>>.UnSuccessFul(400, "401,403 unauthorized-forbidden");
            }
            httpClient.SetBearerToken(TokenResponse.AccessToken);
          return await  httpClient.GetFromJsonAsync<ResponseDto<List<OneChildKategoriler>>>("KategoryList");
        }
        public async Task<ResponseDto<RootKategoriDto>> ThreeChildKategoriesList()
        {
            var TokenResponse = await ClientCredentialsRequest();
            if (TokenResponse.IsError)
            {
                return ResponseDto<RootKategoriDto>.UnSuccessFul(40, "401-403 unauthorized-forbidden");
            }
            httpClient.SetBearerToken(TokenResponse.AccessToken!);
            
            return await httpClient.GetFromJsonAsync<ResponseDto<RootKategoriDto>>("ThreeChildKategoryiesList");
        }   

        public async Task<ResponseDto<List<UstKategoriUrunlerDto>>> UstKategoriler(string KategoriName)
        {
            var TokenResponse = await ClientCredentialsRequest();
            if(TokenResponse.IsError)
            {
                return ResponseDto<List<UstKategoriUrunlerDto>>.UnSuccessFul(400, "401-403 unauthorized");
            }
            httpClient.SetBearerToken(TokenResponse.AccessToken!);

            return await httpClient.GetFromJsonAsync<ResponseDto<List<UstKategoriUrunlerDto>>>($"UstKategoriUrunlerGetir/{KategoriName}");
        }


        public async Task<ResponseDto<List<AltKategoriUrunlerDto>>> AltKategoriler(string KategoriName)
        {
            var TokenResponse = await ClientCredentialsRequest();
            if(TokenResponse.IsError)
            {
                return ResponseDto<List<AltKategoriUrunlerDto>>.UnSuccessFul(400, "401-403 unauthorized");
            }
            httpClient.SetBearerToken(TokenResponse.AccessToken!);

            return await httpClient.GetFromJsonAsync<ResponseDto<List<AltKategoriUrunlerDto>>>($"AltKategoriUrunlerGetir/{KategoriName}");
        }
    }
    
}
