using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class Size:Baseclass
    {
        public string SizeName { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}
