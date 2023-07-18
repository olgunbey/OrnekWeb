using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Repository.IRepository.KategoriIRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Repository.KategoriRepository
{
    public class KategoriReadRepository : ReadRepository<Kategoriler>, KategoriIReadRepository
    {
        public KategoriReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<IQueryable<Kategoriler>> GetKategorilersAsync()
        {
            return Task.FromResult( _dbSet.Include(x => x.OneChildKategori)
                  .ThenInclude(x => x.TwoChildKategori)
                  .ThenInclude(x => x.ThreeChildKategori)
                  .ThenInclude(x => x.TwoChildKategorilers)
                  .ThenInclude(x => x.OneChildKategorilers)
                  .ThenInclude(x => x.OneChildRelationshipCinsiyets).AsQueryable());

        }
    }
}
