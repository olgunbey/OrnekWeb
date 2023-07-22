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
            var ResponseDto = await _httpClientUrunlerApi.ThreeChildKategoriesList();

            //ilk başta kategorileri getir
            return View(ResponseDto.Data);
        }
        [HttpGet]
        public async Task<IActionResult> KategoriGetir()
        {

            return View();
        }
    }
}
