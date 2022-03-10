using Shared.Models.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.IServices.Identity
{
    public interface ISignInService
    {
        bool IsSignedIn(ClaimsPrincipal principal);
        Task<SignInResult> PasswordSignInAsync(string EmailId, string password, bool isPersistent, bool lockoutOnFailure);
        Task SignInAsync(User user, bool isPersistent, string authenticationMethod = null);
        Task SignOutAsync();
    }
}