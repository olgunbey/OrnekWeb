using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.KategoriIBusiness;
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
        public UrunlerController(KategoriIReadBusiness kategoriIReadBusiness)
        {
            _kategoriIReadBusiness = kategoriIReadBusiness;
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
            return ResponseDto<(List<ThreeChildKategori>, List<OneChildKategoriler>, List<TwoChildKategoriler>)>.ResponseStruct<(List<ThreeChildKategori>, List<OneChildKategoriler>, List<TwoChildKategoriler>)>.Response(await _kategoriIReadBusiness.ThreeChildKategoriList());
        }
    }
}
