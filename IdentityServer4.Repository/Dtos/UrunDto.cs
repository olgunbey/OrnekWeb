﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class UrunDto
    {
        public int UrunID { get; set; }
        public string UrunName{ get; set; }
        public int KategoriID { get; set; }
        public KategoriDto KategoriDto { get; set; }
    }
}
