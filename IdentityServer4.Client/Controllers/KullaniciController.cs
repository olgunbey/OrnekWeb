using IdentityServer4.Client.HttpClients;
using IdentityServer4.Client.Models;
using IdentityServer4.Repository.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IdentityServer4.Client.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly HttpClientKullaniciApi kullaniciApi;
        public KullaniciController(HttpClientKullaniciApi httpClientKullaniciApi)
        {
            kullaniciApi = httpClientKullaniciApi;
        }
        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KayitOl(KullaniciKayitOlDto kullaniciKayitOlDto)
        {
            ResponseDto<NoContentDto> responseDto= await kullaniciApi.KullaniciKayitOl(kullaniciKayitOlDto);
            if(responseDto.Errors!=null)
            {
                responseDto.Errors.ForEach(err =>
                {
                    ModelState.AddModelError("error1", err);
                });
                return View();
            }
            TempData["SuccessMessage"] = "Kayıt olma işlemi başarılı,giriş ekranına yönlendiriliyorsunuz...";
            return RedirectToAction(nameof(GirisYap));
        }
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GirisYap(KullaniciGirisDto kullaniciGirisDto)
        {
            
            return View();
        }
    }
}
