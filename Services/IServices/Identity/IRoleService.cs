using Shared.Models.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.IServices.Identity
{
    public interface IRoleService
    {
        IQueryable<Role> Roles { get; }
    }
}