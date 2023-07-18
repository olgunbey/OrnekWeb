using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class Urunler:Baseclass
    {
        public string? UrunName{ get; set; }
        public Kategoriler? Kategori { get; set; }
        public int KategoriID  { get; set; }
    }
}
