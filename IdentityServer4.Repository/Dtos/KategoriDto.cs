using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class KategoriDto
    {
        public int? Id { get; set; }
        public string? KategoriName { get; set; }
        public ICollection<MarkalarDto>  MarkalarDtos{ get; set; }
    }
}
