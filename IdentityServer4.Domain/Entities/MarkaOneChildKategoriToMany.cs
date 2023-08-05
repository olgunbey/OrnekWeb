using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class MarkaOneChildKategoriToMany:Baseclass
    {
        public int MarkaID { get; set; }
        public int KategoriID { get; set; }
        public Markalar Markalar { get; set; }
        public Kategoriler Kategoriler{ get; set; }
    }
}
