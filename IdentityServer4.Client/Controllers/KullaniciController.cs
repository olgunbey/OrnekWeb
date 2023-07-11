using IdentityServer4.Client.ConstString;
using IdentityServer4.Client.HttpClients;
using IdentityServer4.Client.Models;
using IdentityServer4.Repository.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
                    ModelState.AddModelError("errorKayit", err);
                });
                return View();
            }
            return RedirectToAction(nameof(YasakliYer));
        }
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(KullaniciGirisDto kullaniciGirisDto)
        {
            var responseDto = await kullaniciApi.KullaniciGiris(kullaniciGirisDto);
            if (responseDto.Errors != null)
            {
                responseDto.Errors.ForEach(err =>
                {
                    ModelState.AddModelError("errorGiris", err);
                });
                return View();
            }
            await HttpContext.SignInAsync("Cookies", responseDto.Data.Item1, responseDto.Data.Item2);
            TempData["SuccessMessage"] = StringExample.GirisBasarili;
            return View();
        }
        [Authorize(Policy ="YasakliYer")]
        [HttpGet]
        public IActionResult YasakliYer()
        {
            return View();
        }
        
    }
}
