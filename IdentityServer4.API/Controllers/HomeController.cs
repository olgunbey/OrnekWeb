
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.API.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [Authorize(Policy ="Policy1")]
        [HttpGet]
        public IActionResult Listele()
        {
          
            return Ok();
        }
    }
}
