using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class Kategoriler:Baseclass
    {
        public string? KategoriName{ get; set; }
        public OneChildKategoriler? OneChildKategori{ get; set; }

        public int? OneChildKategoriID { get; set; }

        public ICollection<Urunler> Urunlers{ get; set; }
    }
}
