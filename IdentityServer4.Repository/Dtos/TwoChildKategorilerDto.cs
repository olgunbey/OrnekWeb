using IdentityServer4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class TwoChildKategorilerDto
    {
        public int? ID{ get; set; }
        public string? TwoChildKategoriName { get; set; }
        public ThreeChildKategoriDto ThreeChildKategoriDtos { get; set; }
        public int? ThreeChildID { get; set; }
    }
}
