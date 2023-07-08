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
    public interface UyelerIWriteBusiness:IBusinessWrite<Kullanicilar>
    {
        Task<ResponseDto<NoContentDto>> NewAddAsync(Kullanicilar entity);
    }
}
