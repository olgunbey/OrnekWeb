using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class OneChildRelationshipCinsiyet:Baseclass
    {
        public Cinsiyet Cinsiyet { get; set; }
        public OneChildKategoriler OneChildKategori { get; set; }
        public int OneChildID { get; set; }
        public int CinsiyetID{ get; set; }

    }
}
