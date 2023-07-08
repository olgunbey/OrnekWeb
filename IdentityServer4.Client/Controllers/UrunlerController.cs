using IdentityServer4.Client.HttpClients;
using IdentityServer4.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.Client.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly HttpClientApi _httpApi;
        public UrunlerController(HttpClientApi httpApi)
        {
            _httpApi = httpApi;
        }
        public async Task<IActionResult> Listele()
        {
           
         List<UrunlerModelView> urunler= await _httpApi.HomeListeleApi();
            return View(urunler);
        }
    }
}
