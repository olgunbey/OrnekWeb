using IdentityServer4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class KullaniciRolDto
    {
        public Kullanicilar Kullanicilar{ get; set; }
        public RolesDto Role { get; set; }
    }
}
