using Shared.Models.Base;
using Shared.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Identity
{
    public interface IUserService
    {

        IQueryable<User> Users { get; }

        Task<CustomIdentityResult> ChangePasswordAsync(long user, string currentPassword, string newPassword);
        Task<bool> CheckPasswordAsync(long user, string password);
        Task<CustomIdentityResult> CreateAsync(User user);
        Task<CustomIdentityResult> CreateAsync(User user, string password);
        bool Equals(object obj);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByIdAsync(string userId);
        Task<string> GeneratePasswordResetTokenAsync(long user);
        Task<IList<string>> GetRolesAsync(long user);
        Task<User> GetUserAsync(ClaimsPrincipal principal);
        string GetUserId(ClaimsPrincipal principal);
        Task<bool> IsEmailConfirmedAsync(long user);
        Task<bool> IsInRoleAsync(long user, string role);
        Task<CustomIdentityResult> ResetPasswordAsync(long user, string token, string newPassword);
        Task<CustomIdentityResult> UpdateAsync(User user);
        void ManageLoginDeviceInfo(string userId, short deviceType, string deviceToken, string Token, int TimezoneOffsetInSeconds);
        ApiResponses<bool> Logout(string userId);
        void UpdateUserToken(string userId, string Token);
        Task<bool> SaveToken(long userId, string token, bool isUpdate);
    }
}
