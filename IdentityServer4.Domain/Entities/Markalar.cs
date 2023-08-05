using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class Markalar:Baseclass
    {
        public string MarkaName { get; set; }
        public ICollection<Urunler> Urunlers { get; set; }

        public ICollection<MarkaOneChildKategoriToMany> MarkaOneChildKategoriToManies { get; set; }
    }
}
