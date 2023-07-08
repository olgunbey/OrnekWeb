using AutoMapper;
using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Business.UyelerBusiness
{
    public class UyelerReadBusiness : ReadBusiness<Kullanicilar>, UyelerIReadBusiness
    {
        public UyelerReadBusiness(IReadRepository<Kullanicilar> readRepository,IMapper mapper) : base(readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;

        }
        private readonly IMapper _mapper;
        private readonly IReadRepository<Kullanicilar> _readRepository;
        public async Task<ResponseDto<Kullanicilar>> KullaniciGiris(KullaniciGirisDto kullaniciGirisDto)
        {
          Kullanicilar kullanicilar= await _readRepository.GetAsync(x => x.KullaniciName == kullaniciGirisDto.KullaniciName && x.KullaniciSifre == kullaniciGirisDto.KullaniciSifre);

            return kullanicilar != null ? ResponseDto<Kullanicilar>.Success(kullanicilar, 200) : ResponseDto<Kullanicilar>.UnSuccessFul(200, "Kullanıcı bulunamadı");
        }
    }
}
