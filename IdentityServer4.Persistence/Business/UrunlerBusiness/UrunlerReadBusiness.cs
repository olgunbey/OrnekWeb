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

        public async Task<ResponseDto<List<Urunler>>> GetCategoryUrunler(int categoryId)
        {
         var Response=await(await  _urunlerIReadRepository.GetIdCategory(categoryId)).ToListAsync();
         if(Response.Count == 0)
            {
                throw new EmptyException("bu kategori boştur");
            }
            return ResponseDto<List<Urunler>>.Success(Response, 200);
        }
    }
}
