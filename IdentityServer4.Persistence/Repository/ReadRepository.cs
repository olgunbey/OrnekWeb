using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : Baseclass, new()
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public ReadRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
            _dbSet=_context.Set<T>();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
          return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async ValueTask<T> GetIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public  Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null)
        {
            return Task.FromResult(_dbSet.Where(predicate).AsQueryable());
        }
    }
}
