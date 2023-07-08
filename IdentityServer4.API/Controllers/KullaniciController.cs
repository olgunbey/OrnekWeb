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

        [HttpPost]
        public async Task<IActionResult> KullaniciEkle(KullaniciEkleDto kullaniciEkleDto)
        {
           Kullanicilar kullanicilar = _mapper.Map<Kullanicilar>(kullaniciEkleDto);
           await _uyelerIWriteBusiness.AddAsync(kullanicilar);
           return ResponseDto<NoContentDto>.ResponseStruct<NoContentDto>.Response(ResponseDto<NoContentDto>.Success(200));
        }
        //[HttpGet]
        //public async Task<IActionResult> KullanicilariListele()
        //{
        // List<Kullanicilar> kullanicilars= await (await _uyelerIReadBusiness.GetListAsync()).ToListAsync();



        //    ResponseDto<List<KullaniciDto>>.ResponseStruct<List<KullaniciDto>>.Response();
        //}
        [HttpPost("NewKullaniciEkle")]
        public async Task<IActionResult> NewKullaniciEkle(KullaniciEkleDto kullaniciEkleDto)
        {
            Kullanicilar kullanicilar = _mapper.Map<Kullanicilar>(kullaniciEkleDto);
            var response=  await _uyelerIWriteBusiness.NewAddAsync(kullanicilar);
            return ResponseDto<NoContentDto>.ResponseStruct<NoContentDto>.Response(response);
        }
        [HttpPost("KullaniciSorgula")]
        public async Task<IActionResult> KullaniciSorgula(KullaniciGirisDto kullaniciGirisDto)
        {
            return ResponseDto<Kullanicilar>.ResponseStruct<Kullanicilar>.Response(await _uyelerIReadBusiness.KullaniciGiris(kullaniciGirisDto));

        }
    }
}
