using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class Role:Baseclass
    {
        public string RoleName { get; set; }
        [JsonIgnore]
        public ICollection<RoleKullanicilarManyToMany> RoleKullanicilarManyToManies { get; set; }
    }
}
