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
            string escapeDataKategori=  Uri.EscapeDataString(KategoriName);
            return await httpClient.GetFromJsonAsync<ResponseDto<List<UstKategoriUrunlerDto>>>($"UstKategoriUrunlerGetir/{escapeDataKategori}");
        }


        public async Task<ResponseDto<List<AltKategoriUrunlerDto>>> AltKategoriler(string KategoriName)
        {
            var TokenResponse = await ClientCredentialsRequest();
            if(TokenResponse.IsError)
            {
                return ResponseDto<List<AltKategoriUrunlerDto>>.UnSuccessFul(400, "401-403 unauthorized");
            }
            httpClient.SetBearerToken(TokenResponse.AccessToken!);
            string escapeDataKategori = Uri.EscapeDataString(KategoriName);

            return await httpClient.GetFromJsonAsync<ResponseDto<List<AltKategoriUrunlerDto>>>($"AltKategoriUrunlerGetir/{escapeDataKategori}");
        }

        public async Task<ResponseDto<List<UrunListeleDto>>> UrunListele(string kategoriName)
        {
            var TokenResponse = await ClientCredentialsRequest();
            if(TokenResponse.IsError)
            {
                return ResponseDto<List<UrunListeleDto>>.UnSuccessFul(401, "401-403 unauthorized");
            }
            _httpClient.SetBearerToken(TokenResponse.AccessToken!);

            return (await _httpClient.GetFromJsonAsync<ResponseDto<List<UrunListeleDto>>>($"UrunlerListele/{kategoriName}"))!;

        }

        public async Task<ResponseDto<List<ProductDetailDto>>> ProductDetails(int id)
        {
            var TokenResponse = await ClientCredentialsRequest();
            if(TokenResponse.IsError)
            {
                return ResponseDto<List<ProductDetailDto>>.UnSuccessFul(401, "401-403 unauthorized forbidden");
            }
            _httpClient.SetBearerToken(TokenResponse.AccessToken!);

           return await _httpClient.GetFromJsonAsync<ResponseDto<List<ProductDetailDto>>>($"GetUrunDetails/{id}");

        }

        public async Task<ResponseDto<List<MarkalarDto>>> ProductCategoryList(string KategoriName)
        {
            var TokenResponse = await ClientCredentialsRequest();
            if(TokenResponse.IsError)
            {
                return ResponseDto<List<MarkalarDto>>.UnSuccessFul(401, "401-403 unauthorized");
            }
        return await _httpClient.GetFromJsonAsync<ResponseDto<List<MarkalarDto>>>($"ProductCategoryDetails/{KategoriName}");
        }
    }
    
}
