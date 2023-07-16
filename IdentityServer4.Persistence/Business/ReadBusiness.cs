using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Business
{
    public class ReadBusiness<T> : IBusinesRead<T> where T : Baseclass, new()
    {
        private readonly IReadRepository<T> _readRepository;
        public ReadBusiness(IReadRepository<T> readRepository)
        {
            _readRepository = readRepository;

        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
         T entity= await _readRepository.GetAsync(predicate);
            return entity != null ? entity : entity; //hata fırlat middleware'de yakala
        }

        public async ValueTask<T> GetIdAsync(int id)
        {
            T entity=await _readRepository.GetIdAsync(id);
            return entity != null ? entity : entity; //hata fırlat middleware'de yakala
        }

        public async Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null)
        {
           var entities= await _readRepository.GetListAsync(predicate);
            return entities!=null ? entities : Enumerable.Empty<T>().AsQueryable();

        }
    }
}
