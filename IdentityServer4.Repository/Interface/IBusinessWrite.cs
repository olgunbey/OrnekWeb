using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Interface
{
    public interface IBusinessWrite<T> where T : Baseclass,new()
    {
        Task<ResponseDto<NoContentDto>> AddAsync(T entity);
        Task AddAsync(IEnumerable<T> entites);
        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        Task DeleteAsync(IEnumerable<T> entites, IQueryable<T> values);
    }
}
