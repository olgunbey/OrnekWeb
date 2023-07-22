using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.IBusiness.RoleIBusiness;
using IdentityServer4.Repository.IBusiness.UrunlerIBusiness;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Business.UrunlerBusiness
{
    public class UrunlerWriteBusiness : WriteBusiness<Urunler>, UrunlerIWriteBusiness
    {
        public UrunlerWriteBusiness(IWriteRepository<Urunler> writeRepository, IUnitOfWorks unitOfWorks, RoleIReadBusiness readBusiness) : base(writeRepository, unitOfWorks, readBusiness)
        {
        }
    }
}
