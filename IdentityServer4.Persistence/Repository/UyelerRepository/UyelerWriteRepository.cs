using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Persistence.Repository;
using IdentityServer4.Repository.UyelerIRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Repository.UyelerRepository
{
    public class UyelerWriteRepository : WriteRepository<Kullanicilar>, UyelerIWriteRepository
    {
        public UyelerWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
