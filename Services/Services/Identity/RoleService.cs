using Services.IServices.Identity;
using Shared.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services.Identity
{
    public class RoleService : IRoleService
    {
        public IQueryable<Role> Roles => throw new NotImplementedException();
    }
}
