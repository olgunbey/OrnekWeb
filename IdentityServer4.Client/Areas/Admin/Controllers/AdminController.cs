using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
