using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.KategoriIBusiness;
using IdentityServer4.Repository.Interface;
using IdentityServer4.Repository.IRepository.KategoriIRepository;
using Microsoft.AspNetCore.Routing.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Business.KategoriBusiness
{
    public class KategoriReadBusiness : ReadBusiness<Kategoriler>, KategoriIReadBusiness
    {
        private readonly KategoriIReadRepository _kategoriIReadRepository;
        public KategoriReadBusiness(IReadRepository<Kategoriler> readRepository,KategoriIReadRepository kategoriIReadRepository) : base(readRepository)
        {
            _kategoriIReadRepository = kategoriIReadRepository;
        }

        public async Task<ResponseDto<List<AltKategoriUrunlerDto>>> AltKategorilerList(string kategoriName)
        {
         var kategorilers=await _kategoriIReadRepository.AltKategoriler(kategoriName);
            var abc = kategorilers.ToList();
         var KategoriDto= kategorilers.Select(x => new AltKategoriUrunlerDto()
            {
                ID=x.Id,
                UrunDtos=x.Kategorilers.SelectMany(y=>y.Urunlers).Select(s=>new UrunDto() {UrunID=s.Id,UrunName=s.UrunName }).ToList()
            }).ToList();
            return ResponseDto<List<AltKategoriUrunlerDto>>.Success(KategoriDto,200);
        }

        public async Task<ResponseDto<List<OneChildKategoriler>>> KategoryList()
        {
            var Kategorilers= await (await _kategoriIReadRepository.GetKategorilersAsync()).ToListAsync();
            return ResponseDto<List<OneChildKategoriler>>.Success(Kategorilers, 200);
        }
        
        public async Task<ResponseDto<RootKategoriDto>> ThreeChildKategoriList()
        {
        var Data= (await  _kategoriIReadRepository.GetThreeChildKategoriesAsync());
            var newTuple1 = await Data.Item1.ToListAsync();
            var newTuple2= await Data.Item2.ToListAsync();
            var newTuple3= await Data.Item3.ToListAsync();

        var OneChildKategorilerDtos= newTuple2.Select(x => new OneChildKategorilerDto()
            {
             ID=x.Id,
             Kategori=x.Kategorilers.Select(y=> new KategoriDto()
             {
                 Id=y.Id,
                 KategoriName=y.KategoriName,

             }).ToList(),
             OneChildKategoriName =x.OneChildKategoriName,
             TwoChildKategorilerDto=new TwoChildKategorilerDto()
             {
                 ID=x.TwoChildKategori is null?null :x.TwoChildKategori.Id,
                 TwoChildKategoriName=x.TwoChildKategori is null?null: x.TwoChildKategori.TwoChildKategoriName,
                 ThreeChildKategoriDtos=new ThreeChildKategoriDto()
                 {
                     ID=x.TwoChildKategori is not null? x.TwoChildKategori.ThreeChildKategori.Id:null,
                     ThreeChildKategoriName=x.TwoChildKategori is not null?x.TwoChildKategori.ThreeChildKategori.ThreeChildKategoriName:null
                 }


             },
             ThreeChildKategoriDto=new ThreeChildKategoriDto()
             {
                 ID=x.ThreeChildKategoriID,
                 ThreeChildKategoriName=x.ThreeChildKategori is null?null: x.ThreeChildKategori.ThreeChildKategoriName,
             } ,
             ThreeChildKategoriID=x.ThreeChildKategoriID,
             TwoChildKategoriID=x.TwoChildKategoriID
            }).ToList();

        var ThreeChildKategorilerDtos = newTuple1.Select(x => new ThreeChildKategoriDto()
            {
                ID=x.Id,
                ThreeChildKategoriName=x.ThreeChildKategoriName
            }).ToList();

            var TwoChildKategorilerDtos = newTuple3.Select(x => new TwoChildKategorilerDto()
            {
                ID=x.Id,
                ThreeChildKategoriDtos=new ThreeChildKategoriDto() 
                { 
                ID=x.ThreeChildKategori.Id
                },
                TwoChildKategoriName=x.TwoChildKategoriName,
                ThreeChildID=x.ThreeChildKategoriID
            }).ToList();

            var RootDto = new RootKategoriDto()
            {
                OneChildKategorilerDtos = OneChildKategorilerDtos,
                ThreeChildKategoriDtos = ThreeChildKategorilerDtos,
                TwoChildKategorilerDtos = TwoChildKategorilerDtos
            };

            return ResponseDto<RootKategoriDto>.Success(RootDto, 200);
            
        }

        public async Task<ResponseDto<List<UstKategoriUrunlerDto>>> UstKategorilerList(string kategoriName)
        {
            var UstKategori = await _kategoriIReadRepository.UstKategoriler(kategoriName);

        var ResponseDto= await UstKategori.Select(x => new UstKategoriUrunlerDto()
            {
                Id=x.Id,
               UrunDtos= x.OneChildKategorilers.SelectMany(y => y.Kategorilers).SelectMany(a => a.Urunlers).Select(b => new UrunDto()
                {
                    UrunID = b.Id,
                    UrunName=b.UrunName
                }).ToList()
            }).ToListAsync();

            return ResponseDto<List<UstKategoriUrunlerDto>>.Success(ResponseDto, 200);
        }
    }
}
