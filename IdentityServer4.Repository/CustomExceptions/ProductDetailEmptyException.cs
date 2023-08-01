using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.CustomExceptions
{
    public class ProductDetailEmptyException:Exception
    {
        public ProductDetailEmptyException(string _mgs):base(_mgs) { }
    }
}
