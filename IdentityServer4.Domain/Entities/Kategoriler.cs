using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class Kategoriler:Baseclass
    {
        public string KategoriName{ get; set; }
        [JsonIgnore]
        public OneChildKategoriler? OneChildKategori{ get; set; }

        public int? OneChildKategoriID { get; set; }

        public ICollection<Urunler> Urunlers{ get; set; }
        public ICollection<MarkaOneChildKategoriToMany> MarkaOneChildKategoriToManies { get; set; }

    }
}
