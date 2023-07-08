using IdentityServer4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Interface
{
    public interface IBusinesRead<T> :IReadRepository<T> where T : Baseclass,new()
    {
    }
}
