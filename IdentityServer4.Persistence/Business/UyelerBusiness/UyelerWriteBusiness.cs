using AutoMapper;
using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.RoleIBusiness;
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
        
        public UyelerWriteBusiness(IWriteRepository<Kullanicilar> writeRepository, IUnitOfWorks unitOfWorks,IMapper mapper,RoleIReadBusiness roleIReadBusiness) : base(writeRepository, unitOfWorks,roleIReadBusiness)
        {
            _unitOfWorks = unitOfWorks;
            _writeRepository = writeRepository;
            _mapper= mapper;
        }
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IWriteRepository<Kullanicilar> _writeRepository;
        public async Task<ResponseDto<NoContentDto>> NewAddAsync(KullaniciKayitOlDto entity)
        {
           Kullanicilar newEntity= _mapper.Map<Kullanicilar>(entity);
            if(!newEntity.KullaniciSifre.Contains(newEntity.KullaniciName))
            {
                await _writeRepository.AddAsync(newEntity);
                await _unitOfWorks.SaveAsync();
                return ResponseDto<NoContentDto>.Success(201);
            }
            return ResponseDto<NoContentDto>.UnSuccessFul(200, "Kullanıcı şifresinde ad içermektedir");
        }
    }
}
