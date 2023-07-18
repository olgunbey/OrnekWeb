using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class Cinsiyet:Baseclass
    {
        public string CinsiyetAdi{ get; set; }
        public ICollection<OneChildRelationshipCinsiyet> OneChildRelationshipCinsiyets { get; set; }
    }
}
