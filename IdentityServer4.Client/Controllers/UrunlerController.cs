using IdentityServer4.Client.HttpClients;
using IdentityServer4.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.Client.Controllers
{
    public class UrunlerController : Controller
    {

        private readonly HttpClientUrunlerApi _httpClientUrunlerApi;
        public UrunlerController(HttpClientUrunlerApi httpClientUrunlerApi)
        {
            _httpClientUrunlerApi = httpClientUrunlerApi;
        }
        [HttpGet]
        public async Task<IActionResult> Anasayfa()
        {
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AltKategori(string kategories)
        {
         var ResponseDTo= await _httpClientUrunlerApi.AltKategoriler(kategories);
            return View(ResponseDTo.Data);
        }
        [HttpGet]
        public async Task<IActionResult> UstKategori(string kategori)
        {
          var ResponseDto= await _httpClientUrunlerApi.UstKategoriler(kategori);
            return View(ResponseDto.Data);
        }
    }
}
