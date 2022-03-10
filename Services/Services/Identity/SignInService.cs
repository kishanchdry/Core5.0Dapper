using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Services.IServices.Identity;
using Shared.Models.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Services.Services.Identity
{
    public class SignInService : ISignInService
    {
        public bool IsSignedIn(ClaimsPrincipal principal)
        {
            return principal.Claims.Count() > 0;
        }

        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            throw new NotImplementedException();
        }

        public Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            throw new NotImplementedException();
        }

        public Task SignInAsync(User user, bool isPersistent, string authenticationMethod = null)
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
