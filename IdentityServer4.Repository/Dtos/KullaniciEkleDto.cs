using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class KullaniciEkleDto
    {
        public string? KullaniciAd { get; set; }
        public string? KullaniciMail { get; set; }
        public string? KullaniciName { get; set; }
        public string? KullaniciSifre { get; set; }
    }
}
