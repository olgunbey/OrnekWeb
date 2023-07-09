using AutoMapper;
using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Kullanicilar, KullaniciEkleDto>().ReverseMap();
            CreateMap<KullaniciDto, Kullanicilar>().ReverseMap();
            CreateMap<KullaniciEkleDto, Kullanicilar>().ReverseMap();
            CreateMap<Kullanicilar,KullaniciKayitOlDto>().ReverseMap();
        }

    }
}
