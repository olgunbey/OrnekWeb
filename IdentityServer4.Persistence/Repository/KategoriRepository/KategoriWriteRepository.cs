using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Repository.IRepository.KategoriIRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Repository.KategoriRepository
{
    public class KategoriWriteRepository : WriteRepository<Kategoriler>, KategoriIWriteRepository
    {
        public KategoriWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
