using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.IBusiness.UrunlerIBusiness
{
    public interface UrunlerIReadBusiness:IBusinesRead<Urunler>
    {
        Task<ResponseDto<List<Urunler>>> GetCategoryUrunler(int categoryId);
    }
}
