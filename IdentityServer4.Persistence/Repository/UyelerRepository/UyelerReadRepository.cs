using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Persistence.Repository;
using IdentityServer4.Repository.CustomExceptions;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.Interface;
using IdentityServer4.Repository.IRepository.UyelerIRepository;
using IdentityServer4.Repository.IRepository.RolesIRepository;
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

        public Task<IQueryable<Kullanicilar>> KullaniciRolesGetir()
        {
            return Task.FromResult(_dbSet.Include(opt => opt.RoleKullanicilarManyToManies).ThenInclude(opt => opt.Role).AsQueryable());
        }

    }
}
