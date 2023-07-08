using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.AuthServer.Controllers
{
    public class KayitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
