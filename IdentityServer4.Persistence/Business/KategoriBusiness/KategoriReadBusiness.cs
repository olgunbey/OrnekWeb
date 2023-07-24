using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.KategoriIBusiness;
using IdentityServer4.Repository.Interface;
using IdentityServer4.Repository.IRepository.KategoriIRepository;
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

        public async Task<ResponseDto<List<OneChildKategoriler>>> AltKategorilerList(string kategoriName)
        {
         var kategorilers=await _kategoriIReadRepository.AltKategoriler(kategoriName);
            return ResponseDto<List<OneChildKategoriler>>.Success(await kategorilers.ToListAsync(),200);
        }

        public async Task<ResponseDto<List<OneChildKategoriler>>> KategoryList()
        {
            var Kategorilers= await (await _kategoriIReadRepository.GetKategorilersAsync()).ToListAsync();
            return ResponseDto<List<OneChildKategoriler>>.Success(Kategorilers, 200);
        }
        
        public async Task<ResponseDto<Tuple<List<ThreeChildKategori>, List<OneChildKategoriler>, List<TwoChildKategoriler>>>> ThreeChildKategoriList()
        {
        var Data= (await  _kategoriIReadRepository.GetThreeChildKategoriesAsync());
            var newTuple1 = await Data.Item1.ToListAsync();
            var newTuple2= await Data.Item2.ToListAsync();
            var newTuple3= await Data.Item3.ToListAsync();

            var x= (newTuple1, newTuple2, newTuple3).ToTuple();
            return ResponseDto<Tuple<List<ThreeChildKategori>, List<OneChildKategoriler>, List<TwoChildKategoriler>>>.Success(x, 200);
            
        }

        public async Task<ResponseDto<List<TwoChildKategoriler>>> UstKategorilerList(string kategoriName)
        {
           ;
            return ResponseDto<List<TwoChildKategoriler>>.Success(await (await _kategoriIReadRepository.UstKategoriler(kategoriName)).ToListAsync(), 200);
        }
    }
}
