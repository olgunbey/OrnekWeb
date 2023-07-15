using IdentityServer4.Client.HttpClients;
using IdentityServer4.Repository.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IdentityServer4.Client.Controllers
{
    [Authorize(Policy ="AdminPanel")]
    public class AdminController : Controller
    {
        private readonly HttpClientKullaniciApi _clientKullaniciApi;
        public AdminController(HttpClientKullaniciApi httpClientKullaniciApi)
        {
            _clientKullaniciApi = httpClientKullaniciApi;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Uyeler()
        {
          var ResponseKullaniciRoller= await _clientKullaniciApi.KullaniciRollerGetir();
            return View(ResponseKullaniciRoller);
        }

        [HttpGet]
        public async Task<IActionResult> RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(string RoleName)
        {
            RoleEkleDto roleEkleDto = new();
            roleEkleDto.RoleName = RoleName;
          ResponseDto<NoContentDto> ResponseDto=  await _clientKullaniciApi.RoleCreate(roleEkleDto);

          if(ResponseDto.Errors == null)
            {
                TempData["SuccessMessage"] = "Başarıyla role kaydedildi";
                return View();
            }
            ResponseDto.Errors.ForEach(e =>
            {
                ModelState.AddModelError("roleCreateError", e);
            });
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RoleUpdate(int roleID,string kullaniciId)
        {
            TempData["roleID"] = roleID;
            TempData["kullaniciId"]= kullaniciId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(string RoleName)
        {
            var roleId= TempData["roleID"];
            var kullaniciId = TempData["kullaniciId"];
            var ResponseDto= await _clientKullaniciApi.RoleUpdate(Convert.ToInt32(roleId), Convert.ToInt32(kullaniciId),RoleName);

            if (ResponseDto.Data)
            {
                TempData["SuccessMessage"] = "Başarıyla role güncellediniz";
                return View();
            }
            ResponseDto.Errors?.ForEach(error =>
            {
                ModelState.AddModelError("error",error);
            });
            return View();
        }

    }
}
