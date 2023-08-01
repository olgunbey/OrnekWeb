using IdentityServer4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class UrunListeleDto:Baseclass
    {
        public string UrunAdı { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
