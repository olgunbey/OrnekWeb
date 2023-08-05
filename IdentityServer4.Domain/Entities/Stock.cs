using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class Stock:Baseclass
    {
        public int UrunlerID { get; set; }
        public int RenklerID{ get; set; }
        public int? SizeID { get; set; }
        public int Stok { get; set; }
        public Urunler Urunler { get; set; }
        public Color Color{ get; set; }
        public Size? Size { get; set; }
        
    }
}
