using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Interface
{
    public interface IUnitOfWorks
    {
        void Save();
        Task SaveAsync();
    }
}
