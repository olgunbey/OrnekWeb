using IdentityServer4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class ThreeChildKategoriDto
    {
        public int? ID { get; set; }
        public string? ThreeChildKategoriName { get; set; }

        public ICollection<TwoChildKategorilerDto>? TwoChildKategorilers { get; set; }

        public ICollection<OneChildKategorilerDto>? OneChildKategorilers { get; set; }
    }
}
