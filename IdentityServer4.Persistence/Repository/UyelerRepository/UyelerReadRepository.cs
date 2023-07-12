using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Persistence.Repository;
using IdentityServer4.Repository.UyelerIRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.UyelerRepository
{
    public class UyelerReadRepository : ReadRepository<Kullanicilar>, UyelerIReadRepository
    {
        public UyelerReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }


        public async Task<List<RoleKullanicilarManyToMany>> KullaniciRoleGetir(int kullaniciID)
        {
          var kullaniciEntity= (await _dbSet.FirstOrDefaultAsync(x=>x.Id==kullaniciID));
         return await _dbSet.Entry(kullaniciEntity).Collection(opt => opt.RoleKullanicilarManyToManies).Query().Include(opt=>opt.Role).ToListAsync();
        }
    }
}
