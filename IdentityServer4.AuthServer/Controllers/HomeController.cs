using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.AuthServer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
