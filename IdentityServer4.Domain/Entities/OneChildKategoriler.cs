using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class OneChildKategoriler:Baseclass
    {
        public string OneChildKategoriName{ get; set; }
        public ICollection<Kategoriler> Kategorilers{ get; set; }
        public TwoChildKategoriler TwoChildKategori { get; set; }
        public int? TwoChildKategoriID{ get; set; }
        public ICollection<OneChildRelationshipCinsiyet> OneChildRelationshipCinsiyets { get; set; }

        public ThreeChildKategori? ThreeChildKategori{ get; set; }
        public int? ThreeChildKategoriID{ get; set; }
    }
}
