﻿using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.IBusiness.KategoriIBusiness
{
    public interface KategoriIReadBusiness:IBusinesRead<Kategoriler>
    {
        Task<ResponseDto<List<OneChildKategoriler>>> KategoryList();
        Task<ResponseDto<List<AltKategoriUrunlerDto>>> AltKategorilerList(string kategoriName);
        Task<ResponseDto<List<UstKategoriUrunlerDto>>> UstKategorilerList(string kategoriName);
        Task<ResponseDto<RootKategoriDto>> ThreeChildKategoriList();
    }
}
