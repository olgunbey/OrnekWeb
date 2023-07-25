using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class RootKategoriDto
    {
        public List<ThreeChildKategoriDto> ThreeChildKategoriDtos{ get; set; }
        public List<TwoChildKategorilerDto> TwoChildKategorilerDtos { get; set; }
        public List<OneChildKategorilerDto>  OneChildKategorilerDtos{ get; set; }

    }
}
