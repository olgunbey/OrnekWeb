using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class ProductDetail:Baseclass
    {
        public string Description { get; set; }
        public int Price{ get; set; }
        public int Evaluation { get; set; }
        public Urunler Urunler { get; set; }
        public int UrunlerID { get; set; }

    }
}
