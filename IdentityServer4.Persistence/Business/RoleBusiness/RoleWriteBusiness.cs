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
    public class RoleWriteBusiness : WriteBusiness<Role>, RoleIWriteBusiness
    {
        public RoleWriteBusiness(IWriteRepository<Role> writeRepository, IUnitOfWorks unitOfWorks, RoleIReadBusiness roleIReadBusiness) : base(writeRepository, unitOfWorks,roleIReadBusiness)
        {
        }
    }
}
