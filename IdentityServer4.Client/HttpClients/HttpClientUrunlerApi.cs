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
        public async Task<ResponseDto<Tuple<List<ThreeChildKategori>, List<OneChildKategoriler>, List<TwoChildKategoriler>>>> ThreeChildKategoriesList()
        {
            var TokenResponse = await ClientCredentialsRequest();
            if (TokenResponse.IsError)
            {
                return ResponseDto<Tuple<List<ThreeChildKategori>, List<OneChildKategoriler>, List<TwoChildKategoriler>>>.UnSuccessFul(40, "401-403 unauthorized-forbidden");
            }
            httpClient.SetBearerToken(TokenResponse.AccessToken!);
            
            return await httpClient.GetFromJsonAsync<ResponseDto<Tuple<List<ThreeChildKategori>, List<OneChildKategoriler>, List<TwoChildKategoriler>>>>("ThreeChildKategoryiesList");
        }   
    }
}
