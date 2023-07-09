using AutoMapper;
using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly UyelerIWriteBusiness _uyelerIWriteBusiness;
        private readonly IMapper _mapper;
        private readonly UyelerIReadBusiness _uyelerIReadBusiness;
        public KullaniciController(UyelerIWriteBusiness uyelerIWriteBusiness,IMapper mapper, UyelerIReadBusiness uyelerIReadBusiness)
        {
            _uyelerIWriteBusiness = uyelerIWriteBusiness;
            _mapper = mapper;
            _uyelerIReadBusiness = uyelerIReadBusiness;

        }
        [Authorize("PolicyClient")]
        [HttpPost("KullaniciEkle")]
        public async Task<IActionResult> KullaniciEkle(KullaniciKayitOlDto kullaniciKayitOlDto) //eski kullanıcı kayıt ol api'si alttaki güncel
        {
           Kullanicilar kullanicilar = _mapper.Map<Kullanicilar>(kullaniciKayitOlDto);
           await _uyelerIWriteBusiness.AddAsync(kullanicilar);
           return ResponseDto<NoContentDto>.ResponseStruct<NoContentDto>.Response(ResponseDto<NoContentDto>.Success(200));
        }
        [Authorize("PolicyClient")]
        [HttpPost("NewKullaniciEkle")]
        public async Task<IActionResult> NewKullaniciEkle(KullaniciKayitOlDto kullaniciKayitOlDto) //kullanıcı kayıt ol
        {
            var response=  await _uyelerIWriteBusiness.NewAddAsync(kullaniciKayitOlDto);
            return ResponseDto<NoContentDto>.ResponseStruct<NoContentDto>.Response(response);
        }
        [Authorize("PolicyClient")]
        [HttpPost("KullaniciSorgula")]
        public async Task<IActionResult> KullaniciSorgula(KullaniciGirisDto kullaniciGirisDto) //kullanicigiriş için.
        {
            return ResponseDto<Kullanicilar>.ResponseStruct<Kullanicilar>.Response(await _uyelerIReadBusiness.KullaniciGiris(kullaniciGirisDto));
        }


        
        
        
    }
}
