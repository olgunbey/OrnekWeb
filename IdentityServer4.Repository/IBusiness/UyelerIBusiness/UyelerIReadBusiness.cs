using IdentityServer4.Domain.Entities;
using IdentityServer4.Repository.Dtos;
using IdentityServer4.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.IBusiness.UyelerIBusiness
{
    public interface UyelerIReadBusiness:IBusinesRead<Kullanicilar>
    {
        Task<ResponseDto<Kullanicilar>> KullaniciGiris(KullaniciGirisDto kullaniciGirisDto);
        Task<ResponseDto<List<KullaniciRoleDto>>> KullaniciRoleGetir(int kullaniciID);

        Task<ResponseDto<string>> KullanicilarRoleGetir();
        Task<ResponseDto<bool>> KullaniciRoleUpdate(int roleID, int kullaniciID, string roleName);
        Task<ResponseDto<string>> KullaniciRoleEkle(int kullaniciId, string RoleName);

        Task<ResponseDto<List<Urunler>>> UrunlerListele(string kategoriName);


    }
}
