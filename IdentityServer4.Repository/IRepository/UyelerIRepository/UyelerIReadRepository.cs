﻿using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.IRepository.UyelerIRepository
{
    public interface UyelerIReadRepository : IReadRepository<Kullanicilar>
    {
        Task<List<RoleKullanicilarManyToMany>> KullaniciRoleGetir(int kullaniciID);
        Task<IQueryable<Kullanicilar>> KullaniciRolesGetir();
    }
}
