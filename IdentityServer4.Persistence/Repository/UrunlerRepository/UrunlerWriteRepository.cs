using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Repository.IRepository.IUrunlerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Repository.UrunlerRepository
{
    public class UrunlerWriteRepository : WriteRepository<Urunler>, UrunlerIWriteRepository
    {
        public UrunlerWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
