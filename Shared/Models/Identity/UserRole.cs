using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Identity
{
    public class Role
    {
        public byte Id { get; set; }
        public string RoleName { get; set; }
    }

    public class UserRole
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public byte RoleId { get; set; }
    }
}