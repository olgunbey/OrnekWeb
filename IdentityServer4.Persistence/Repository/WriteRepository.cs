using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : Baseclass, new()
    {
        protected AppDbContext AppDbContext;
        protected DbSet<T> DbSet;
        public WriteRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            DbSet=AppDbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
           await AppDbContext.AddAsync(entity);
            
        }

        public async Task AddAsync(IEnumerable<T> entites)
        {
          await AppDbContext.AddRangeAsync(entites); 
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.FromResult(AppDbContext.Remove(entity));
        }

        public async Task DeleteAsync(IEnumerable<T> entites,IQueryable<T> values)
        {
           await values.ExecuteDeleteAsync();
        }

        public async Task UpdateAsync(T entity)
        {
           await Task.FromResult(AppDbContext.Update(entity));
        }


    }
}
