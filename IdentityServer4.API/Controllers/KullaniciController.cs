using AutoMapper;
using AutoMapper.Configuration.Conventions;
using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.RoleIBusiness;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace IdentityServer4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly UyelerIWriteBusiness _uyelerIWriteBusiness;
        private readonly IMapper _mapper;
        private readonly UyelerIReadBusiness _uyelerIReadBusiness;
        private readonly RoleIWriteBusiness _roleIWriteBusiness;
        private readonly RoleIReadBusiness _roleIReadBusiness;
        public KullaniciController(UyelerIWriteBusiness uyelerIWriteBusiness,IMapper mapper, UyelerIReadBusiness uyelerIReadBusiness,RoleIWriteBusiness roleIWriteBusiness,RoleIReadBusiness roleIReadBusiness)
        {
            _uyelerIWriteBusiness = uyelerIWriteBusiness;
            _mapper = mapper;
            _uyelerIReadBusiness = uyelerIReadBusiness;
            _roleIWriteBusiness = roleIWriteBusiness;
            _roleIReadBusiness= roleIReadBusiness;
        }
        [HttpPost("KullaniciEkle")]
        [Authorize(Policy ="PolicyClient")]
        public async Task<IActionResult> KullaniciEkle(KullaniciKayitOlDto kullaniciKayitOlDto) //eski kullanıcı kayıt ol api'si alttaki güncel
        {
           Kullanicilar kullanicilar = _mapper.Map<Kullanicilar>(kullaniciKayitOlDto);
           await _uyelerIWriteBusiness.AddAsync(kullanicilar);
           return ResponseDto<NoContentDto>.ResponseStruct<NoContentDto>.Response(ResponseDto<NoContentDto>.Success(200));
        }
        [HttpPost("NewKullaniciEkle")]
        [Authorize(Policy ="PolicyClient")]
        public async Task<IActionResult> NewKullaniciEkle(KullaniciKayitOlDto kullaniciKayitOlDto) //kullanıcı kayıt ol
        {
            var response=  await _uyelerIWriteBusiness.NewAddAsync(kullaniciKayitOlDto);
            return ResponseDto<NoContentDto>.ResponseStruct<NoContentDto>.Response(response);
        }
        [HttpPost("KullaniciSorgula")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> KullaniciSorgula(KullaniciGirisDto kullaniciGirisDto) //kullanicigiriş için.
        {
            return ResponseDto<Kullanicilar>.ResponseStruct<Kullanicilar>.Response(await _uyelerIReadBusiness.KullaniciGiris(kullaniciGirisDto));
        }
        [HttpGet("[action]/{id}")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> KullaniciRoleGetir(int id)
        {
            return ResponseDto<List<KullaniciRoleDto>>.ResponseStruct<List<KullaniciRoleDto>>.Response(await _uyelerIReadBusiness.KullaniciRoleGetir(id));
        }
        [HttpGet("KullanicilarRolleriGetir")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> KullanicilarRolleriGetir()
        {
           var deserialize= JsonSerializer.Deserialize<List<KullaniciRollerDto>>((await _uyelerIReadBusiness.KullanicilarRoleGetir()).Data);
            return Ok(deserialize);
        }
        
        [HttpPost("RoleOlustur")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> RoleCreate(RoleEkleDto RoleName)
        {
            return ResponseDto<NoContentDto>.ResponseStruct<NoContentDto>.Response(await _roleIWriteBusiness.AddAsync(new Role() { RoleName = RoleName.RoleName }));
        }

        [HttpGet("[action]/{roleID}/{kullaniciID}/{newRoleName}")]
        [Authorize(Policy = "PolicyClient")]

        public async Task<IActionResult> RoleUpdate(int roleID,int kullaniciID,string newRoleName)
        {
            return ResponseDto<bool>.ResponseStruct<bool>.Response(await _uyelerIReadBusiness.KullaniciRoleUpdate(roleID, kullaniciID, newRoleName));
        }

        [HttpGet("RoleListele")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> RoleListele()
        {
            IQueryable<Role> roles= await _roleIReadBusiness.GetListAsync();

          List<RollerDto> rollerDtos= await roles.Select(x => new RollerDto()
            {
                RoleName = x.RoleName,
            }).ToListAsync();

            return ResponseDto<List<RollerDto>>.ResponseStruct<List<RollerDto>>.Response(ResponseDto<List<RollerDto>>.Success(rollerDtos, 200));
        }
        [HttpGet("[action]/{kullaniciId}/{RoleName}")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> KullaniciRoleEkle(int kullaniciId,string RoleName)
        {
         var Response=  await _uyelerIReadBusiness.KullaniciRoleEkle(kullaniciId, RoleName);

         return ResponseDto<string>.ResponseStruct<string>.Response(Response);
        }

        
        
        
    }
}
