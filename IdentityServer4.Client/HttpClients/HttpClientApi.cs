


using IdentityModel.Client;
using IdentityServer4.Client.Models;
using static IdentityModel.OidcConstants;

namespace IdentityServer4.Client.HttpClients
{
    public class HttpClientApi
    {
        private readonly HttpClient _httpClient;
        public HttpClientApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UrunlerModelView>> HomeListeleApi()
        {
            var tokenRequest = new ClientCredentialsTokenRequest();
            tokenRequest.ClientId = "Client1";
            tokenRequest.ClientSecret = "secret";
            tokenRequest.Address = "https://localhost:7291/connect/token";            

         var tokenResponse=await _httpClient.RequestClientCredentialsTokenAsync(tokenRequest);
            if (tokenResponse.IsError)
            {
                //hata varsa
            }
            _httpClient.SetBearerToken(tokenResponse.AccessToken!);

         HttpResponseMessage httpResponseMessage= await _httpClient.GetAsync("Home");
            if(!httpResponseMessage.IsSuccessStatusCode)
            {
                //başarılı değilse(unauthorized forbidden!)
            }
          return await httpResponseMessage.Content.ReadFromJsonAsync<List<UrunlerModelView>>();

        }
    }
}
