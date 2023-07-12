using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class RoleKullanicilarManyToMany:Baseclass
    {
        public int KullaniciID { get; set; }
        public int RoleID { get; set; }
        public Kullanicilar Kullanicilar { get; set; }
        public Role Role { get; set; }
    }
}
