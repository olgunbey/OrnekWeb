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
           //ilk başta kategorileri getir
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> KategoriGetir()
        {
         var ResponseDto=  await _httpClientUrunlerApi.ThreeChildKategoriesList();
            return View(ResponseDto.Data);
        }
    }
}
