using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Repository.IRepository.RolesIRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Repository.RolesRepository
{
    public class RolesReadRepository : ReadRepository<Role>,RolesIReadRepository
    {
        public RolesReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
