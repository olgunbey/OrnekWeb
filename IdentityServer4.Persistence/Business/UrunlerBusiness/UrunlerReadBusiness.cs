using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.CustomExceptions;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.UrunlerIBusiness;
using IdentityServer4.Repository.Interface;
using IdentityServer4.Repository.IRepository.IUrunlerRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Business.UrunlerBusiness
{
    public class UrunlerReadBusiness : ReadBusiness<Urunler>, UrunlerIReadBusiness
    {
        private readonly UrunlerIReadRepository _urunlerIReadRepository;

        public UrunlerReadBusiness(IReadRepository<Urunler> readRepository,UrunlerIReadRepository urunlerIReadRepository) : base(readRepository)
        {
            _urunlerIReadRepository = urunlerIReadRepository;
        }

        public async Task<ResponseDto<List<MarkalarDto>>> CategoryMarkaList(string kategoriName)
        {
          var Product= await (await  _urunlerIReadRepository.KategoriMarkaList(kategoriName)).ToListAsync();
            List<MarkalarDto> markalarDtos = Product.Select(x => new MarkalarDto()
            {
                MarkaName=x.Markalar.MarkaName,
            }).ToList();
            return ResponseDto<List<MarkalarDto>>.Success(markalarDtos, 200);
        }

        public async Task<ResponseDto<List<UrunDto>>> GetCategoryUrunler(int categoryId)
        {
         var Response=await(await  _urunlerIReadRepository.GetIdCategory(categoryId)).ToListAsync();
         if(Response.Count == 0)
            {
                throw new EmptyException("bu kategori boştur");
            }
          var ResponseDto=  Response.Select(x => new UrunDto()
            {
                UrunID=x.Id,
                UrunName=x.UrunName
            }).ToList();
            return ResponseDto<List<UrunDto>>.Success(ResponseDto, 200);
        }

        public async Task<ResponseDto<int>> KategoriUrunSayisi(int id)
        {
            var Count = (await _urunlerIReadRepository.UrunSayi(id));
            return ResponseDto<int>.Success(Count,200);
        }

        public async Task<ResponseDto<List<ProductDetailDto>>> ProductDetails(int id)
        {
         var ProductDetail=await(await _urunlerIReadRepository.ProductDetail(id)).ToListAsync();

          var ProductDetailDto=  ProductDetail.Select(x =>new ProductDetailDto()
            {
                Description=x.ProductDetail.Description,
                ProductDetailID=x.ProductDetail.Id,
                KategoriID=x.KategoriID,
                Price=x.ProductDetail.Price,
                KategoriName=x.Kategori.KategoriName,
                Evaulation=x.ProductDetail.Evaluation,
                Stock=x.Stocks.Select(x=> new StockDto()
                {
                     Stok=x.Stok,
                     RenkAdi=x.Color.RenkIsim
                }).ToList(),
            
            }).ToList();

            return ResponseDto<List<ProductDetailDto>>.Success(ProductDetailDto, 200);

        }

        public async Task<ResponseDto<List<UrunListeleDto>>> UrunlerListele(string kategoriName)
        {
        List<Urunler> urunlers= await (await _urunlerIReadRepository.UrunlerListele(kategoriName)).ToListAsync();

            if(urunlers is null)
            {
               return ResponseDto<List<UrunListeleDto>>.Success(200);
            }
           List<UrunListeleDto> UrunListele= urunlers.Select(x => new UrunListeleDto()
            {
                Id=x.Id,
                UrunAdı=x.UrunName,
                Description=x.ProductDetail.Description,
                Price=x.ProductDetail.Price,
            }).ToList();

               return ResponseDto<List<UrunListeleDto>>.Success(UrunListele, 200);

           
        }

        public async Task<ResponseDto<List<OneChildKategoriProductKategoriler>>> ProductKategori(string name)
        {
         var Product= await (await _urunlerIReadRepository.ProductKategori(name)).ToListAsync();

            var ProductDto = Product.Select(x => new OneChildKategoriProductKategoriler()
            {
                KategoriDtos = x.Kategorilers.Select(y => new KategoriDto()
                {
                    Id = y.Id,
                    KategoriName = y.KategoriName,
                    MarkalarDtos=x.Kategorilers.SelectMany(x=>x.Urunlers).Select(z=>z.Markalar).Select(z=>new MarkalarDto()
                    {
                        MarkaName=z.MarkaName,
                    }).ToList()
                })
            }).ToList();
            return ResponseDto<List<OneChildKategoriProductKategoriler>>.Success(ProductDto, 200);
        }
    }
}
