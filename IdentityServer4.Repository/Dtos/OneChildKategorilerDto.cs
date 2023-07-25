using IdentityServer4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class OneChildKategorilerDto
    {
        public int ID { get; set; }
        public List<KategoriDto>? Kategori{ get; set; }
        public string OneChildKategoriName { get; set; }

        public TwoChildKategorilerDto? TwoChildKategorilerDto { get; set; }
        public ThreeChildKategoriDto? ThreeChildKategoriDto { get; set; }
        public int? TwoChildKategoriID { get; set; }
        public int? ThreeChildKategoriID { get; set; }
        public ICollection<UrunDto> UrunlerDtos { get; set; }
    }
}
