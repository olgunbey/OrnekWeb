using IdentityServer4.Client.HttpClients;
using IdentityServer4.Client.Models;
using IdentityServer4.Repository.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Cryptography.X509Certificates;

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
            TempData["abc"] = kategories;
            return View(ResponseDTo.Data);
        }
        [HttpGet]
        public async Task<IActionResult> UstKategori(string kategori)
        {
          var ResponseDto= await _httpClientUrunlerApi.UstKategoriler(kategori);
            return View(ResponseDto.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Urunler(string kategoriName)
        {
             
            
            var ResponseDto = await _httpClientUrunlerApi.UrunListele(kategoriName);
            if(ResponseDto.Errors!=null?ResponseDto.Errors.Any():false)
            {
                ResponseDto.Errors.ForEach(x =>
                {
                    ModelState.AddModelError("Hata", x);
                });
            }
            return View(ResponseDto.Data);
        }
        [HttpGet]
        public async Task<IActionResult> UrunlerDetails(int id)
        {
         var ProductDetails= await _httpClientUrunlerApi.ProductDetails(id);
            if(ProductDetails is not null)
            {

                if(ProductDetails.Errors!=null ? ProductDetails.Errors.Any() : true)
                {
                    return View(ProductDetails.Data);
                }
                ProductDetails.Errors.ForEach(errors =>
                {
                    ModelState.AddModelError("ProductDetailError", errors);
                });
                return View();
                
            }
            ModelState.AddModelError("ProductDetailsNull", "Product detayı boş geldi");
            return View();
            
            
        }
 
    }
}
