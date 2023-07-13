using IdentityServer4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class KullaniciRollerDto
    {
        public int KullaniciID { get; set; }
        public string KullaniciName{ get; set; }
        public List<Role> Role { get; set; }
    }
}
