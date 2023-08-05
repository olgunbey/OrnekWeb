using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.IRepository.IUrunlerRepository
{
    public interface UrunlerIReadRepository:IReadRepository<Urunler>
    {
        Task<IQueryable<Urunler>> GetIdCategory(int CategoryID);
        Task<IQueryable<Urunler>> UrunlerListele(string kategoriName);
        Task<IQueryable<Urunler>> ProductDetail(int id);
        Task<IQueryable<Urunler>> GetProductCategory(int id);

        Task<IQueryable<Urunler>> KategoriMarkaList(string categoryName);
        Task<int> UrunSayi(int id);
        Task<IQueryable<OneChildKategoriler>> ProductKategori(string oneChildKategori);
        Task<IQueryable<ThreeChildKategori>> ThreeChildKategoriesList();
        Task<IQueryable<OneChildKategoriler>> TwoChildCategoriesList();
        Task<IQueryable<OneChildKategoriler>> OneChildCategoriesList();
        Task<IQueryable<TwoChildKategoriler>> TwoChildCategori();
        Task<IQueryable<Kategoriler>> KategorilerList(int categoryID);
        Task<IQueryable<MarkaOneChildKategoriToMany>> BrandList(int id);
        Task<IQueryable<Color>> ColorList();
        Task<IQueryable<Size>> SizeList();
    }
}
