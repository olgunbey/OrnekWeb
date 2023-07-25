using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class UstKategoriUrunlerDto
    {
        public int Id { get; set; }
        public ICollection<UrunDto> UrunDtos { get; set; }
    }
}
