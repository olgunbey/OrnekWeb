using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Domain.Entities
{
    public class Kullanicilar:Baseclass
    {
        public string? KullaniciAd { get; set; }
        public string? KullaniciMail { get; set; }
        public string? KullaniciName { get; set; }
        public string? KullaniciSifre { get; set; }
    }
}
