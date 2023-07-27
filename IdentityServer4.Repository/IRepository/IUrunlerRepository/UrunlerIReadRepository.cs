using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.IRepository.IUrunlerRepository
{
    public interface UrunlerIReadRepository:IReadRepository<Urunler>
    {
        Task<IQueryable<Urunler>> GetIdCategory(int CategoryID);
        Task<IQueryable<Urunler>> UrunlerListele(string kategoriName);
    }
}
