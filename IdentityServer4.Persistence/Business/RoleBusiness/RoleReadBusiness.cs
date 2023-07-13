using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.IBusiness.RoleIBusiness;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Business.RoleBusiness
{
    public class RoleReadBusiness : ReadBusiness<Role>, RoleIReadBusiness
    {
        public RoleReadBusiness(IReadRepository<Role> readRepository) : base(readRepository)
        {
        }
    }
}
