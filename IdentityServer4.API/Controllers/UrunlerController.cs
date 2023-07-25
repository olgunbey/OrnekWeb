using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.KategoriIBusiness;
using IdentityServer4.Repository.IBusiness.UrunlerIBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        private readonly KategoriIReadBusiness _kategoriIReadBusiness;
        private readonly UrunlerIReadBusiness _urunlerIReadBusiness;
        public UrunlerController(KategoriIReadBusiness kategoriIReadBusiness,UrunlerIReadBusiness urunlerIReadBusiness)
        {
            _kategoriIReadBusiness = kategoriIReadBusiness;
            _urunlerIReadBusiness = urunlerIReadBusiness;
        }

        [HttpGet("KategoryList")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> KategoryList()
        {
           return ResponseDto<List<OneChildKategoriler>>.ResponseStruct<List<OneChildKategoriler>>.Response(await _kategoriIReadBusiness.KategoryList());
        }
        [HttpGet("ThreeChildKategoryiesList")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> ThreeChildKategoryiesList()
        {
            return ResponseDto<RootKategoriDto>.
                ResponseStruct<RootKategoriDto>.
                Response(await _kategoriIReadBusiness.ThreeChildKategoriList());
        }
        [HttpGet("[action]/{KategoriID}")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> CategoryIdUrunler(int KategoriID)
        {
            return ResponseDto<List<UrunDto>>.ResponseStruct<List<UrunDto>>.Response(await _urunlerIReadBusiness.GetCategoryUrunler(KategoriID));
        }
        [HttpGet("[action]/{kategoriName}")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> AltKategoriUrunlerGetir(string kategoriName)
        {
            string katgori = Uri.UnescapeDataString(kategoriName);
            return ResponseDto<List<AltKategoriUrunlerDto>>.ResponseStruct<List<AltKategoriUrunlerDto>>.Response(await _kategoriIReadBusiness.AltKategorilerList(katgori));
        }
        [HttpGet("[action]/{kategoriName}")]
        [Authorize(Policy = "PolicyClient")]

        public async Task<IActionResult> UstKategoriUrunlerGetir(string kategoriName)
        {
            string katgori=  Uri.UnescapeDataString(kategoriName);
            return ResponseDto<List<UstKategoriUrunlerDto>>.ResponseStruct<List<UstKategoriUrunlerDto>>.Response(await _kategoriIReadBusiness.UstKategorilerList(katgori));
        }
    }
}
