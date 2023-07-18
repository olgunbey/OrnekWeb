using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class TwoChildKategoriler:Baseclass
    {
        public string? TwoChildKategoriName{ get; set; }
        public ICollection<OneChildKategoriler> OneChildKategorilers { get; set; }

        public ThreeChildKategori ThreeChildKategori { get; set; }
        public int ThreeChildKategoriID { get; set; }
    }
}
