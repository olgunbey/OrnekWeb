using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Urunler Product { get; set; }
        public int UrunlerID { get; set; }
        public string FileName { get; set; }
        public string FileByte64 { get; set; }

    }
}
