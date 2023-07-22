using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Repository.IRepository.IUrunlerRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Repository.UrunlerRepository
{
    public class UrunlerReadRepository : ReadRepository<Urunler>, UrunlerIReadRepository
    {
        public UrunlerReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<IQueryable<Urunler>> GetIdCategory(int CategoryID)
        {
            return Task.FromResult(_dbSet.Where(x => x.KategoriID == CategoryID));
        }
    }
}
