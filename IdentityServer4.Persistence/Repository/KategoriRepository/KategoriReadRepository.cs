﻿using IdentityServer4.Domain.Entities;
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

        public Task<IQueryable<OneChildKategoriler>> AltKategoriler(string KategoriName)
        {
            return Task.FromResult(oneChildKategorilersdbset.Include(x=>x.Kategorilers)
                .ThenInclude(x=>x.Urunlers).ThenInclude(x=>x.Markalar)
                .Where(x=>x.OneChildKategoriName==KategoriName));
        }

        public Task<IQueryable<OneChildKategoriler>> GetKategorilersAsync( )
        {
           return Task.FromResult(oneChildKategorilersdbset.Include(x=>x.Kategorilers)
                .Include(x => x.ThreeChildKategori)
                .Include(x => x.TwoChildKategori)
                .ThenInclude(x=>x.ThreeChildKategori).AsQueryable());
        }

        public Task<Tuple<IQueryable<ThreeChildKategori>,IQueryable<OneChildKategoriler>,IQueryable<TwoChildKategoriler>>> GetThreeChildKategoriesAsync()
        {
            return Task.FromResult((threeChildKategoris.AsQueryable(),oneChildKategorilersdbset.Include(x=>x.TwoChildKategori).Include(x=>x.ThreeChildKategori).Include(x=>x.Kategorilers).AsQueryable(),twoChildKategorilerdbset.AsQueryable()).ToTuple());
        }

        public Task<IQueryable<TwoChildKategoriler>> UstKategoriler(string kategoriName)
        {
            return Task.FromResult(twoChildKategorilerdbset.Include(x => x.OneChildKategorilers)
                .ThenInclude(x => x.Kategorilers)
                .ThenInclude(x => x.Urunlers)
                .Where(x => x.TwoChildKategoriName == kategoriName));
        }
    }
}
