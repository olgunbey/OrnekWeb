using IdentityServer4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Interface
{
    public interface IReadRepository<T> where T :Baseclass, new()
    {
        Task<T> GetAsync(Expression<Func<T,bool>> predicate=null);

        Task<IQueryable<T>> GetListAsync(Expression<Func<T,bool>> predicate=null);

        ValueTask<T> GetIdAsync(int id);
    }
}
