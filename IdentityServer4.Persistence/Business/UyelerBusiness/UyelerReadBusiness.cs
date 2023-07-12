using AutoMapper;
using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using IdentityServer4.Repository.Interface;
using IdentityServer4.Repository.UyelerIRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Business.UyelerBusiness
{
    public class UyelerReadBusiness : ReadBusiness<Kullanicilar>, UyelerIReadBusiness
    {
        public UyelerReadBusiness(IReadRepository<Kullanicilar> readRepository,IMapper mapper, UyelerIReadRepository uyelerIReadRepository) : base(readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _uyelerIReadRepository = uyelerIReadRepository;

        }
        private readonly UyelerIReadRepository _uyelerIReadRepository;
        private readonly IMapper _mapper;
        private readonly IReadRepository<Kullanicilar> _readRepository;
        public async Task<ResponseDto<Kullanicilar>> KullaniciGiris(KullaniciGirisDto kullaniciGirisDto)
        {
          Kullanicilar kullanicilar= await _readRepository.GetAsync(x => x.KullaniciName == kullaniciGirisDto.KullaniciName && x.KullaniciSifre == kullaniciGirisDto.KullaniciSifre);

            return kullanicilar != null ? ResponseDto<Kullanicilar>.Success(kullanicilar, 200) : ResponseDto<Kullanicilar>.UnSuccessFul(200, "Kullanıcı bulunamadı");
        }

        public async Task<ResponseDto<List<KullaniciRoleDto>>> KullaniciRoleGetir(int kullaniciID)
        {
            var KullaniciRole = await _uyelerIReadRepository.KullaniciRoleGetir(kullaniciID);

            var KullaniciDto = KullaniciRole.Select(opt => new KullaniciRoleDto()
            {
                KullaniciName = opt.Kullanicilar.KullaniciName,
                RoleName = opt.Role.RoleName
            }).ToList();


            return ResponseDto<List<KullaniciRoleDto>>.Success(KullaniciDto, 200);




        }
    }
}
