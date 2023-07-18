using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.IBusiness.KategoriIBusiness;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Business.KategoriBusiness
{
    public class KategoriReadBusiness : ReadBusiness<Kategoriler>, KategoriIReadBusiness
    {
        public KategoriReadBusiness(IReadRepository<Kategoriler> readRepository) : base(readRepository)
        {
        }
    }
}
