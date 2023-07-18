using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class ThreeChildKategori:Baseclass
    {
        public string ThreeChildKategoriName { get; set; }
        public ICollection<TwoChildKategoriler> TwoChildKategorilers { get; set; }
        public ICollection<OneChildKategoriler> OneChildKategorilers{ get; set; }
    }
}
