using AutoMapper;
using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using IdentityServer4.Repository.Interface;
using IdentityServer4.Repository.RolesIRepository;
using IdentityServer4.Repository.UyelerIRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Business.UyelerBusiness
{
    public class UyelerReadBusiness : ReadBusiness<Kullanicilar>, UyelerIReadBusiness
    {
        public UyelerReadBusiness(IReadRepository<Kullanicilar> readRepository,IMapper mapper, UyelerIReadRepository uyelerIReadRepository,RolesIReadRepository rolesIReadRepository,RolesIWriteRepository rolesIWriteRepository,IUnitOfWorks unitOfWorks) : base(readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _uyelerIReadRepository = uyelerIReadRepository;
            _unitOfWorks = unitOfWorks;
            _rolesIWriteRepository = rolesIWriteRepository;
            _rolesIReadRepository = rolesIReadRepository;
        }
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly RolesIWriteRepository _rolesIWriteRepository;
        private readonly RolesIReadRepository _rolesIReadRepository;
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

        public async Task<ResponseDto<string>> KullanicilarRoleGetir()
        {
         List<Kullanicilar> KullanicilarsRole= await (await _uyelerIReadRepository.KullaniciRolesGetir()).ToListAsync();

            List<KullaniciRollerDto> kullaniciRollerDtos = KullanicilarsRole.Select(opt =>
              new KullaniciRollerDto()
              {
                  KullaniciID=opt.Id,
                  KullaniciName=opt.KullaniciName,
                  Role=opt.RoleKullanicilarManyToManies.Select(x=>x.Role).ToList()
              }).ToList();

           var jsonSerializeData= JsonSerializer.Serialize(kullaniciRollerDtos);
            return ResponseDto<string>.Success(jsonSerializeData, 200);

        }

        public async Task<ResponseDto<bool>> KullaniciRoleUpdate(int roleID,int kullaniciID,string roleName)
        {

            try
            {
                Role eskirole = await _rolesIReadRepository.GetIdAsync(roleID);
                Role eklenenrole = await _rolesIReadRepository.GetAsync(x => x.RoleName == roleName);
                if (eklenenrole is null)
                {
                    await _rolesIWriteRepository.AddAsync(new Role() { RoleName = roleName });
                    await _unitOfWorks.SaveAsync();
                    eklenenrole = await _rolesIReadRepository.GetAsync(x => x.RoleName == roleName);
                }
           var kullaniciroller= await (await _uyelerIReadRepository.KullaniciRolesGetir()).ToListAsync();

              var Kullanicilar= kullaniciroller.FirstOrDefault(x => x.Id == kullaniciID);


                //var Kullanicilar = await _readRepository.GetAsync(x => x.RoleKullanicilarManyToManies.FirstOrDefault(x => x.RoleID == eskirole.Id).KullaniciID == kullaniciID);

                var roleKullanicilarManyToMany = Kullanicilar.RoleKullanicilarManyToManies.FirstOrDefault(X => X.RoleID == eskirole.Id);


                roleKullanicilarManyToMany.RoleID = eklenenrole.Id;
                await _unitOfWorks.SaveAsync();
                return ResponseDto<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseDto<bool>.UnSuccessFul(200, "!!");
                throw;
            }
            
        }
    }
}
