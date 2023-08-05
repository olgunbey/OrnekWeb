using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class ProductAddModelView
    {
        public string urunname { get; set; }
        public int kategoriID { get; set; }
        public int markalarID { get; set; }
        public int colorID { get; set; }
        public int stok { get; set; }

        public int Price { get; set; }
        public int? sizeID { get; set; }
        public string description { get; set; }
    }
}
