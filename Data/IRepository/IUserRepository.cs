using Shared.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IUserRepository
    {
        public Task<User> FindByEmailAsync(string email);
        Task<CustomIdentityResult> AddToRolesAsync(long userId, string[] roles);
        Task<CustomIdentityResult> ChangePasswordAsync(long userId, string currentPassword, string newPassword);
        Task<bool> CheckPasswordAsync(long userId, string password);
    }
}
