﻿using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.IBusiness.UrunlerIBusiness
{
    public interface UrunlerIReadBusiness:IBusinesRead<Urunler>
    {
        Task<ResponseDto<List<UrunDto>>> GetCategoryUrunler(int categoryId);
        Task<ResponseDto<List<UrunListeleDto>>> UrunlerListele(string kategoriName);
        Task<ResponseDto<List<ProductDetailDto>>> ProductDetails(int id);

        Task<ResponseDto<List<MarkalarDto>>> CategoryMarkaList(string kategoriName);
        Task<ResponseDto<int>> KategoriUrunSayisi(int id);
        Task<ResponseDto<List<OneChildKategoriProductKategoriler>>> ProductKategori(string name);
        Task<ResponseDto<List<ThreeChildKategori>>> ThreeChildCategoriesList();
        Task<ResponseDto<List<OneChildKategorilerDto>>> TwoChildCategoriesList(int categoryID);
        Task<ResponseDto<List<OneChildKategorilerDto>>> OneChildCategoriesList(string categoryName);
        Task<ResponseDto<List<KategorilerDto>>> KategorilerList(int categoryID);
        Task<ResponseDto<List<MarkalarDto>>> BrandList(int id);
        Task<ResponseDto<List<ColorDto>>> ColorList();
        Task<ResponseDto<List<SizeDto>>> SizeList();

    }
}
