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
        private readonly HttpClientRoleApi _clientRoleApi;
        public AdminController(HttpClientKullaniciApi httpClientKullaniciApi, HttpClientRoleApi clientRoleApi)
        {
            _clientKullaniciApi = httpClientKullaniciApi;
            _clientRoleApi = clientRoleApi;

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
            var ResponseData = await _clientRoleApi.RoleListeleApi();
            return View(ResponseData.Data);
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(string RoleName)
        {
            RoleEkleDto roleEkleDto = new();
            roleEkleDto.RoleName = RoleName;
            ResponseDto<NoContentDto> ResponseDto=  await _clientKullaniciApi.RoleCreate(roleEkleDto);
            var ResponseData = await _clientRoleApi.RoleListeleApi();
            if (ResponseDto.Errors == null)
            {
               

                TempData["SuccessMessage"] = "Başarıyla role kaydedildi";
                return View(ResponseData.Data);
            }
            ResponseDto.Errors.ForEach(e =>
            {
                ModelState.AddModelError("roleCreateError", e);
            });
            return View(ResponseData.Data);
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

        [HttpGet]
        public async Task<IActionResult> KullaniciRoleEkle(int kullaniciId)
        {
            TempData["kullaniciId"] = kullaniciId;
            var ResponseData = await _clientRoleApi.RoleListeleApi();
            try
            {
                if (!ResponseData.Errors.Any())
                {
                    ResponseData.Errors.ForEach(error =>
                    {
                        ModelState.AddModelError("error", error);
                    });
                    return View();
                }
                return View();
                
            }
            catch (Exception e)
            {
                return View(ResponseData.Data);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> KullaniciRoleEkle(string roleName)
        {
           var kullaniciId = (int)TempData["kullaniciId"];

         ResponseDto<string> ResponseDto= await _clientRoleApi.KullaniciRoleEkleApi(kullaniciId, roleName);
            var ResponseData = await _clientRoleApi.RoleListeleApi();
            if(ResponseDto.Errors is not null)
            {
                ResponseDto.Errors.ForEach((error) =>
                {
                    ModelState.AddModelError("kullanicirolekleerror", error);
                });
                return View(ResponseData.Data);
            }
            TempData["SuccessMessage"] = "bu kullanıcıya başarılı rol eklendi";
            return View(ResponseData.Data);
        }


    }
}
