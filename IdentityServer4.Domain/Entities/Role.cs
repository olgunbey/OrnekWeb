﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class Role:Baseclass
    {
        public string RoleName { get; set; }
        public ICollection<Kullanicilar> Kullanicilars { get; set; }
    }
}