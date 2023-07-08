using IdentityServer4.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.Client.Controllers
{
    public class KullaniciController : Controller
    {
        public KullaniciController()
        {
            
        }
        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KayitOl(KullaniciKayitOlModelView kullaniciKayitOlModelView)
        {
            return View();
        }
    }
}
