using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class ProductDetailDto
    {
        public int ProductDetailID { get; set; }
        public ProductDetailUrunDto ProductDetailUrunDto { get; set; }
        public string Description { get; set; }
        public int KategoriID { get; set; }
        public int Price { get; set; }
        public int Evaulation { get; set; }
        public string KategoriName { get; set; }
        public ICollection<StockDto> Stock { get; set; }
    }
}
