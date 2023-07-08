using IdentityServer4.Domain.Entities;
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
        public WriteBusiness(IWriteRepository<T> writeRepository,IUnitOfWorks unitOfWorks)
        {
            Repository = writeRepository;
            _unitOfWorks = unitOfWorks;
        }
        public async Task AddAsync(T entity)
        {
           await Repository.AddAsync(entity);
           await _unitOfWorks.SaveAsync();
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
