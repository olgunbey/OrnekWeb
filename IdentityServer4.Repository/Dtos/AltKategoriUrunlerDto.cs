using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class AltKategoriUrunlerDto
    {
        public int ID { get; set; }
        public ICollection<MarkalarDto> MarkalarDtos { get; set; }
        public ICollection<UrunDto> UrunDtos { get; set; }
    }
}
