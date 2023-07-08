using IdentityServer4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Interface
{
    public interface IWriteRepository<T> where T:Baseclass,new()
    {
        Task AddAsync(T entity);
        Task AddAsync(IEnumerable<T> entites);
        Task UpdateAsync(T entity);
    
        Task DeleteAsync(T entity);
        Task DeleteAsync(IEnumerable<T> entites, IQueryable<T> values);
    }
}
