using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.IBusiness.KategoriIBusiness
{
    public interface KategoriIReadBusiness:IBusinesRead<Kategoriler>
    {
        Task<ResponseDto<List<OneChildKategoriler>>> KategoryList();
        Task<ResponseDto<List<OneChildKategoriler>>> AltKategorilerList(string kategoriName);
        Task<ResponseDto<List<TwoChildKategoriler>>> UstKategorilerList(string kategoriName);
        Task<ResponseDto<Tuple<List<ThreeChildKategori>, List<OneChildKategoriler>, List<TwoChildKategoriler>>>> ThreeChildKategoriList();
    }
}
