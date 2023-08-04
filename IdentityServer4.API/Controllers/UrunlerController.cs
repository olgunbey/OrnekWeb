using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.KategoriIBusiness;
using IdentityServer4.Repository.IBusiness.UrunlerIBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        [HttpGet("[action]/{kategoriName}")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> UrunlerListele(string kategoriName) 
        {
          return ResponseDto<List<UrunListeleDto>>.
                ResponseStruct<List<UrunListeleDto>>.
                Response(await _urunlerIReadBusiness.UrunlerListele(kategoriName));
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> GetUrunDetails(int id)
        {
          return ResponseDto<List<ProductDetailDto>>.ResponseStruct<List<ProductDetailDto>>.Response(await _urunlerIReadBusiness.ProductDetails(id));
        }
        [HttpGet("[action]/{categoryName}")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> ProductCategoryDetails(string categoryName)
        {

            return ResponseDto<List<MarkalarDto>>
                .ResponseStruct<List<MarkalarDto>>
                .Response(await _urunlerIReadBusiness.CategoryMarkaList(categoryName));
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> UrunSayisi(int id)
        {
            return ResponseDto<int>.ResponseStruct<int>.Response(await _urunlerIReadBusiness.KategoriUrunSayisi(id));
        }
        [HttpGet("[action]/{categoryName}")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> KategoriGetir(string categoryName)
        {

            return ResponseDto<List<OneChildKategoriProductKategoriler>>.ResponseStruct<List<OneChildKategoriProductKategoriler>>.Response(await _urunlerIReadBusiness.ProductKategori(categoryName));
        }
        [HttpGet("ThreeChildCategoriesList")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> ThreeChildCategoriesList()
        {
            return ResponseDto<List<ThreeChildKategori>>
                .ResponseStruct<List<ThreeChildKategori>>
                .Response(await _urunlerIReadBusiness.ThreeChildCategoriesList());
        }

        [HttpGet("[action]/{categoryID}")]
        [Authorize(Policy ="PolicyClient")]
        public async Task<IActionResult> TwoChildCategoriesList(int categoryID)
        {
            return ResponseDto<List<TwoChildKategoriler>>
                .ResponseStruct<List<TwoChildKategoriler>>
                .Response(await _urunlerIReadBusiness.TwoChildCategoriesList(categoryID));
        }
        [HttpGet("[action]/{categoryName}")]
        //[Authorize(Policy ="PolicyClient")]

        public async Task<IActionResult> OneChildCategoriesList(string categoryName)
        {

            return ResponseDto<List<OneChildKategorilerDto>>
                .ResponseStruct<List<OneChildKategorilerDto>>
                .Response(await _urunlerIReadBusiness.OneChildCategoriesList(categoryName));
        }
    }
}
