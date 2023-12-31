﻿using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Repository.Dtos;
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

        public Task<IQueryable<Urunler>> GetProductCategory(int categoryid) //bunu düzelt
        {
            return Task.FromResult(_dbSet.Include(x => x.Markalar).Include(x => x.Stocks).ThenInclude(x => x.Color).AsQueryable());
                
        }

        public Task<IQueryable<Urunler>> ProductDetail(int id)
        {
            return Task.FromResult(_dbSet.Include(x => x.ProductDetail)
                .Where(x=>x.ProductDetail.UrunlerID==id)
                .Include(x=>x.Kategori)
                .Include(x => x.Stocks)
                .ThenInclude(x => x.Color).AsQueryable());
        }

        public Task<IQueryable<Urunler>> UrunlerListele(string kategoriName)
        {
           return Task.FromResult(_context.Set<Urunler>()
               .Include(x=>x.Kategori)
               .Where(x=>x.Kategori.KategoriName==kategoriName)
               .Include(x=>x.Markalar)
               .Include(x=>x.Stocks)
               .Include(x=>x.ProductDetail)
               .AsQueryable());
        }

        public Task<IQueryable<Urunler>> KategoriMarkaList(string categoryName)
        {
           return Task.FromResult(_dbSet.Include(x => x.Kategori)
               .Where(x=>x.Kategori.KategoriName==categoryName)
                .Include(x => x.Markalar)
                .AsQueryable());
        }

        public async Task<int> UrunSayi(int id)
        {
          return await _dbSet.Where(x => x.KategoriID == id).CountAsync();

        }

        public Task<IQueryable<OneChildKategoriler>> ProductKategori(string oneChildKategori)
        {
          return Task.FromResult(oneChildKategorilersdbset.Include(x => x.Kategorilers).ThenInclude(x=>x.Urunlers).ThenInclude(x=>x.Markalar)
                .Where(x => x.OneChildKategoriName == oneChildKategori));
        }

        public Task<IQueryable<ThreeChildKategori>> ThreeChildKategoriesList()
        {
            return Task.FromResult(threeChildKategoris.AsQueryable());

        }

        public Task<IQueryable<OneChildKategoriler>> TwoChildCategoriesList()
        {
          return Task.FromResult(oneChildKategorilersdbset.Include(x=>x.ThreeChildKategori).Include(x=>x.TwoChildKategori).AsQueryable());
        }

        public Task<IQueryable<OneChildKategoriler>> OneChildCategoriesList()
        {
            return Task.FromResult(oneChildKategorilersdbset.Include(x => x.ThreeChildKategori).Include(x => x.TwoChildKategori).AsQueryable());
        }
        public Task<IQueryable<TwoChildKategoriler>> TwoChildCategori()
        {
            return Task.FromResult(twoChildKategorilerdbset.Include(x => x.ThreeChildKategori).AsQueryable());
        }

        public Task<IQueryable<Kategoriler>> KategorilerList(int categoryID)
        {
            
            return Task.FromResult(_kategorilerDbSet.Where(x=>x.OneChildKategoriID==categoryID));
        }

        public Task<IQueryable<MarkaOneChildKategoriToMany>> BrandList(int id)
        {
            return Task.FromResult(_markaOneChildKategoriToMany.Include(x=>x.Markalar).Where(y=>y.KategoriID==id)); 
        }

        public Task<IQueryable<Color>> ColorList()
        {
            return Task.FromResult(_colorDbSet.AsQueryable());
        }
        public Task<IQueryable<Size>> SizeList()
        {
            return Task.FromResult(_sizeDbSet.AsQueryable());
        }
            
    }
}
