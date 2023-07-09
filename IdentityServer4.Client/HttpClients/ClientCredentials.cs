using IdentityModel.Client;

namespace IdentityServer4.Client.HttpClients
{
    public class ClientCredentials
    {
        private readonly HttpClient _httpClient;
        public ClientCredentials(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TokenResponse> ClientCredentialsRequest()
        {
            DiscoveryDocumentResponse discoveryDocumentResponse = await _httpClient.GetDiscoveryDocumentAsync("https://localhost:7291");

            var clientCredentialsToken = new ClientCredentialsTokenRequest();
            clientCredentialsToken.ClientId = "Client1";
            clientCredentialsToken.ClientSecret = "secret";
            clientCredentialsToken.Address = discoveryDocumentResponse.TokenEndpoint;

            return await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialsToken);

        }
    }
}
