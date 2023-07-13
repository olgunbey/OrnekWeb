using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class RolesDto
    {
        public List<int> RoleID { get; set; }
        public List<string> RoleName { get; set; }
    }
}
