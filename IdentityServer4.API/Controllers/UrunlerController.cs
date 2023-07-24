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
            return ResponseDto<Tuple<List<ThreeChildKategori>, List<OneChildKategoriler>, List<TwoChildKategoriler>>>.
                ResponseStruct<Tuple<List<ThreeChildKategori>, List<OneChildKategoriler>, List<TwoChildKategoriler>>>.
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
            return ResponseDto<List<OneChildKategoriler>>.ResponseStruct<List<OneChildKategoriler>>.Response(await _kategoriIReadBusiness.AltKategorilerList(kategoriName));
        }
        [HttpGet("[action]/{kategoriName}")]
        [Authorize(Policy = "PolicyClient")]

        public async Task<IActionResult> UstKategoriUrunlerGetir(string kategoriName)
        {
            return ResponseDto<List<TwoChildKategoriler>>.ResponseStruct<List<TwoChildKategoriler>>.Response(await _kategoriIReadBusiness.UstKategorilerList(kategoriName));
        }
    }
}
