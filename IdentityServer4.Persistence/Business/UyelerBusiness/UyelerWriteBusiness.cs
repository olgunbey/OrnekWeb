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
    public class UyelerWriteBusiness : WriteBusiness<Kullanicilar>, UyelerIWriteBusiness
    {
        
        public UyelerWriteBusiness(IWriteRepository<Kullanicilar> writeRepository, IUnitOfWorks unitOfWorks) : base(writeRepository, unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
            _writeRepository = writeRepository;
        }
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IWriteRepository<Kullanicilar> _writeRepository;
        public async Task<ResponseDto<NoContentDto>> NewAddAsync(Kullanicilar entity)
        {
            if(!entity.KullaniciSifre.Contains(entity.KullaniciName))
            {
                await _writeRepository.AddAsync(entity);
                await _unitOfWorks.SaveAsync();
                return ResponseDto<NoContentDto>.Success(201);
            }
            return ResponseDto<NoContentDto>.UnSuccessFul(200, "Kullanıcı şifresinde ad içermektedir");
        }
    }
}
