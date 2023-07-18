using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        [HttpGet("Listele")]

        public async Task<IActionResult> ThreeChildKategoryList()
        {
            return Ok();
        }
    }
}
