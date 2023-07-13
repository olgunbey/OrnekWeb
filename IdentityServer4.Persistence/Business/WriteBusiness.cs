using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.IBusiness.RoleIBusiness;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Business
{
    public class WriteBusiness<T> : IBusinessWrite<T> where T : Baseclass, new()
    {
        private readonly IWriteRepository<T> Repository;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly RoleIReadBusiness _readBusiness;
        public WriteBusiness(IWriteRepository<T> writeRepository,IUnitOfWorks unitOfWorks, RoleIReadBusiness readBusiness)
        {
            Repository = writeRepository;
            _unitOfWorks = unitOfWorks;
            _readBusiness = readBusiness;
        }
        public async Task<ResponseDto<NoContentDto>> AddAsync(T entity)
        {
            if(entity is Role)
            {
                var EntityRole = entity as Role;
                var Role= await _readBusiness.GetAsync(x => x.RoleName ==EntityRole.RoleName);
                if(Role is null)
                {
                    await Repository.AddAsync(entity);
                    await _unitOfWorks.SaveAsync();
                    return ResponseDto<NoContentDto>.Success(201);
                }
                else
                {
                    return ResponseDto<NoContentDto>.UnSuccessFul(200, "böyle bir role bulunmaktadır!");
                }
            }
           await Repository.AddAsync(entity);
           await _unitOfWorks.SaveAsync();
            return ResponseDto<NoContentDto>.Success(201);
        }

        public async Task AddAsync(IEnumerable<T> entites)
        {
            await Repository.AddAsync(entites);
            await _unitOfWorks.SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            await Repository.DeleteAsync(entity);
            await _unitOfWorks.SaveAsync();
        }

        public async Task DeleteAsync(IEnumerable<T> entites, IQueryable<T> values)
        {
            await Repository.DeleteAsync(entites, values);
            await _unitOfWorks.SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Repository.UpdateAsync(entity);
            await _unitOfWorks.SaveAsync();
        }
    }
}
