using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class Urunler:Baseclass
    {
        public string? UrunName{ get; set; }
        [JsonIgnore]
        public Kategoriler? Kategori { get; set; }
        public int KategoriID  { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public Markalar Markalar { get; set; }
        public int MarkalarID { get; set; }
        public ICollection<Stock>  Stocks{ get; set; }

    }
}
