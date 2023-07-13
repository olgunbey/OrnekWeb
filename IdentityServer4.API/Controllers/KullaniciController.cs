using AutoMapper;
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
        public KullaniciController(UyelerIWriteBusiness uyelerIWriteBusiness,IMapper mapper, UyelerIReadBusiness uyelerIReadBusiness,RoleIWriteBusiness roleIWriteBusiness)
        {
            _uyelerIWriteBusiness = uyelerIWriteBusiness;
            _mapper = mapper;
            _uyelerIReadBusiness = uyelerIReadBusiness;
            _roleIWriteBusiness = roleIWriteBusiness;
        }
        [HttpPost("KullaniciEkle")]
        [Authorize("PolicyClient")]
        public async Task<IActionResult> KullaniciEkle(KullaniciKayitOlDto kullaniciKayitOlDto) //eski kullanıcı kayıt ol api'si alttaki güncel
        {
           Kullanicilar kullanicilar = _mapper.Map<Kullanicilar>(kullaniciKayitOlDto);
           await _uyelerIWriteBusiness.AddAsync(kullanicilar);
           return ResponseDto<NoContentDto>.ResponseStruct<NoContentDto>.Response(ResponseDto<NoContentDto>.Success(200));
        }
        [HttpPost("NewKullaniciEkle")]
        [Authorize("PolicyClient")]
        public async Task<IActionResult> NewKullaniciEkle(KullaniciKayitOlDto kullaniciKayitOlDto) //kullanıcı kayıt ol
        {
            var response=  await _uyelerIWriteBusiness.NewAddAsync(kullaniciKayitOlDto);
            return ResponseDto<NoContentDto>.ResponseStruct<NoContentDto>.Response(response);
        }
        [HttpPost("KullaniciSorgula")]
        [Authorize("PolicyClient")]
        public async Task<IActionResult> KullaniciSorgula(KullaniciGirisDto kullaniciGirisDto) //kullanicigiriş için.
        {
            return ResponseDto<Kullanicilar>.ResponseStruct<Kullanicilar>.Response(await _uyelerIReadBusiness.KullaniciGiris(kullaniciGirisDto));
        }
        [HttpGet("[action]/{id}")]
        [Authorize("PolicyClient")]
        public async Task<IActionResult> KullaniciRoleGetir(int id)
        {
            return ResponseDto<List<KullaniciRoleDto>>.ResponseStruct<List<KullaniciRoleDto>>.Response(await _uyelerIReadBusiness.KullaniciRoleGetir(id));
        }
        [HttpGet("KullanicilarRolleriGetir")]
        //[Authorize("PolicyClient")]
        public async Task<IActionResult> KullanicilarRolleriGetir()
        {
           var deserialize= JsonSerializer.Deserialize<List<KullaniciRollerDto>>((await _uyelerIReadBusiness.KullanicilarRoleGetir()).Data);
            return Ok(deserialize);
        }
        
        [HttpPost("RoleOlustur")]
        [Authorize("PolicyClient")]
        public async Task<IActionResult> RoleCreate(RoleEkleDto RoleName)
        {
            return ResponseDto<NoContentDto>.ResponseStruct<NoContentDto>.Response(await _roleIWriteBusiness.AddAsync(new Role() { RoleName = RoleName.RoleName }));
        }


        
        
        
    }
}
