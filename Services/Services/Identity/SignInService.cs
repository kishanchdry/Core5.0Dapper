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
using Services.Generic;
using Data.IRepository;
using AutoMapper;
using Data.IRepository.IGeneric;

namespace Services.Services.Identity
{
    public class SignInService : GenericService<User, User>, ISignInService, IDisposable
    {
        private readonly IUserRepository userRepository;
        public SignInService(IUserRepository _userRepository,IGenericDataRepository<User> repository, IMapper mapper) : base(repository, mapper)
        {
            userRepository = _userRepository;
        }
        public bool IsSignedIn(ClaimsPrincipal principal)
        {
            return principal.Claims.Count() > 0;
        }

        public Task<SignInResult> PasswordSignInAsync(string Email, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return userRepository.PasswordSignInAsync(Email, password, isPersistent, lockoutOnFailure);
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
