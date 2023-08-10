using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.KategoriIBusiness;
using IdentityServer4.Repository.IBusiness.UrunlerIBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileProviders;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Extensions.Primitives;

namespace IdentityServer4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        private readonly KategoriIReadBusiness _kategoriIReadBusiness;
        private readonly UrunlerIReadBusiness _urunlerIReadBusiness;
        private readonly UrunlerIWriteBusiness _urunlerIWriteBusiness;
        private readonly IFileProvider _fileProvider;
        public UrunlerController(KategoriIReadBusiness kategoriIReadBusiness, UrunlerIReadBusiness urunlerIReadBusiness, UrunlerIWriteBusiness urunlerIWriteBusiness, IFileProvider fileProvider)
        {
            _kategoriIReadBusiness = kategoriIReadBusiness;
            _urunlerIReadBusiness = urunlerIReadBusiness;
            _urunlerIWriteBusiness = urunlerIWriteBusiness;
            _fileProvider = fileProvider;

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
            string katgori = Uri.UnescapeDataString(kategoriName);
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
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> TwoChildCategoriesList(int categoryID)
        {
            return ResponseDto<List<OneChildKategorilerDto>>
                .ResponseStruct<List<OneChildKategorilerDto>>
                .Response(await _urunlerIReadBusiness.TwoChildCategoriesList(categoryID));
        }
        [HttpGet("[action]/{categoryName}")]
        [Authorize(Policy = "PolicyClient")]

        public async Task<IActionResult> OneChildCategoriesList(string categoryName)
        {

            return ResponseDto<List<OneChildKategorilerDto>>
                .ResponseStruct<List<OneChildKategorilerDto>>
                .Response(await _urunlerIReadBusiness.OneChildCategoriesList(categoryName));
        }

        [HttpGet("[action]/{categoryID}")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> KategorilerList(int categoryID)
        {
            return ResponseDto<List<KategorilerDto>>
                .ResponseStruct<List<KategorilerDto>>
                .Response(await _urunlerIReadBusiness.KategorilerList(categoryID));
        }
        [HttpGet("[action]/{categoryID}")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> BrandList(int categoryID)
        {
            return ResponseDto<List<MarkalarDto>>
                .ResponseStruct<List<MarkalarDto>>
                .Response(await _urunlerIReadBusiness.BrandList(categoryID));
        }
        [HttpPost("ProductAdd")]
        [Authorize(Policy = "PolicyClient")]

        public async Task<IActionResult> ProductAdd([FromForm]ProductAddModelView model)
        {

         string[] strings= model.filesName.Split('.'); 

         string filetyp= strings.Last(); //fotografın tipini aldık

            Image images;
            model.sizeID= model.sizeID == 0 ? model.sizeID = null : model.sizeID;
            byte[] imageBytes = Convert.FromBase64String(model.files);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {

                images = Image.Load(ms); //fotograf buraya düştü
                
            }
            var DirectoryContent = _fileProvider.GetDirectoryContents("wwwroot");
            if (DirectoryContent.Exists) //wwwroot varsa aşşağıya girecek
            {
                var test = DirectoryContent.FirstOrDefault(x => x.Name == model.kategoriName);
                if(test==null)
                {
                  IFileInfo fileInfo= _fileProvider.GetFileInfo("wwwroot");
                    string PathCombine= Path.Combine(fileInfo.PhysicalPath!, model.kategoriName);
                    Directory.CreateDirectory(PathCombine);
                }
                string? PhysicalPathss = DirectoryContent.FirstOrDefault(x=>x.Name==model.kategoriName).PhysicalPath;
                   
                var newPathCombine = Path.Combine(PhysicalPathss, model.filesName);

                switch (filetyp)
                {
                    case "png":
                        await images.SaveAsync(newPathCombine, new PngEncoder());
                        break;
                    case "jpg":
                        await images.SaveAsync(newPathCombine, new JpegEncoder());
                        break;
                    default:
                        Console.WriteLine("Geçersiz fotoğraf tipi"); //şurayı throw ile yönet
                        break;
                }

            }
            
            


            //await _urunlerIWriteBusiness.AddAsync(new Urunler()
            // { 
            //    MarkalarID=model.markalarID,
            //    KategoriID=model.kategoriID,
            //    UrunName=model.urunname,
            //    Stocks=new List<Stock>()
            //    {
            //        new Stock()
            //        {
            //            Stok=model.stok,
            //            RenklerID=model.colorID
            //        }
            //    },
            //    ProductDetail = new ProductDetail()
            //    {
            //        Price = model.Price,
            //        Description=model.description,
            //    }
            //});
            return Ok();
        }
        [HttpGet("ColorList")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> ColorList()
        {
            return ResponseDto<List<ColorDto>>
                 .ResponseStruct<List<ColorDto>>
                 .Response(await _urunlerIReadBusiness.ColorList());
        }
        [HttpGet("SizeList")]
        [Authorize(Policy = "PolicyClient")]
        public async Task<IActionResult> SizeList()
        {
            return ResponseDto<List<SizeDto>>
                .ResponseStruct<List<SizeDto>>
                .Response(await _urunlerIReadBusiness.SizeList());
        }
    }


}
