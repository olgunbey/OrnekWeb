﻿using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.IRepository.KategoriIRepository
{
    public interface KategoriIReadRepository:IReadRepository<Kategoriler>
    {
         Task<IQueryable<OneChildKategoriler>> GetKategorilersAsync();
        Task<(IQueryable<ThreeChildKategori>, IQueryable<OneChildKategoriler>, IQueryable<TwoChildKategoriler>)> GetThreeChildKategoriesAsync(); 
    }
}
