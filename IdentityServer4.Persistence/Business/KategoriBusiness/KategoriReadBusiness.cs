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

        public async Task<ResponseDto<List<OneChildKategoriler>>> KategoryList()
        {
            var Kategorilers= await (await _kategoriIReadRepository.GetKategorilersAsync()).ToListAsync();
            return ResponseDto<List<OneChildKategoriler>>.Success(Kategorilers, 200);
        }
        public async Task<ResponseDto<(List<ThreeChildKategori>,List<OneChildKategoriler>,List<TwoChildKategoriler>)>> ThreeChildKategoriList()
        {
         var Data= (await  _kategoriIReadRepository.GetThreeChildKategoriesAsync()).ToTuple();
            var newTuple1 =  Data.Item1.ToListAsync();
            var newTuple2= Data.Item2.ToListAsync();
            var newTuple3= Data.Item3.ToListAsync();

         await Task.WhenAll(newTuple1,newTuple2,newTuple3); //hepsini burada beklet

            var result1 = newTuple1.Result;
            var result2 = newTuple2.Result; 
            var result3 = newTuple3.Result;
            return ResponseDto<(List<ThreeChildKategori>, List<OneChildKategoriler>, List<TwoChildKategoriler>)>.Success((result1,result2,result3), 200);
        }
    }
}
