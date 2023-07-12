using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        [Authorize(Policy = "AdminPanel")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
