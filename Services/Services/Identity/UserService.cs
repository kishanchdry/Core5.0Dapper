using Shared.Common.Enums;
using Shared.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Shared.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shared.Models.Identity;
using Data.IRepository;
using Services.IServices.Identity;
using Services.Generic;
using Data.IRepository.IGeneric;
using AutoMapper;
using Shared.Properties;

namespace Services.Services.Identity
{
    public class UserService : GenericService<User, User>, IUserService, IDisposable
    {
        
        private readonly IUserRepository userRepository;

        public IQueryable<User> Users => throw new NotImplementedException();
        public UserService(IUserRepository _userRepository,IGenericDataRepository<User> repository, IMapper mapper) : base(repository, mapper)
        {
            userRepository = _userRepository;
        }


        public Task<User> FindByEmailAsync(string email)
        {
            return userRepository.FindByEmailAsync(email);
        }


        #region Virtual functions


        public Task<CustomIdentityResult> AddToRolesAsync(long UserId, params string[] roles)
        {
            return userRepository.AddToRolesAsync(UserId, roles);
        }

        public Task<CustomIdentityResult> ChangePasswordAsync(long UserId, string currentPassword, string newPassword)
        {
            return userRepository.ChangePasswordAsync(UserId, currentPassword, newPassword);
        }

        public Task<bool> CheckPasswordAsync(long UserId, string password)
        {
            return userRepository.CheckPasswordAsync(UserId, password);
        }

        public Task<bool> ConfirmEmailAsync(User user, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomIdentityResult> CreateAsync(User user)
        {
            CustomIdentityResult customIdentityResult = new();
            var result=await repository.InsertWithReturnIdAsync(user);

            if(result!=null && result.Id>0)
            {
                customIdentityResult.Succeeded = true;
                customIdentityResult.Message = "Error occured";
            }
            else
            {
                customIdentityResult.Succeeded = false;
                customIdentityResult.Message = Resources.EmailNotVerified;
            }
            return customIdentityResult;
        }

        public Task<CustomIdentityResult> DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }



        public Task<User> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            throw new NotImplementedException();
        }



        public Task<CustomIdentityResult> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region API Functions

        public void ManageLoginDeviceInfo(string userId, short deviceType, string deviceToken, string Token, int TimezoneOffsetInSeconds)
        {
            //try
            //{
            //    var deviceObj = _context.UserDeviceInfos.FirstOrDefault(x => x.UserId == userId);
            //    if (deviceObj != null)
            //    {
            //        deviceObj.DeviceToken = deviceToken;
            //        deviceObj.DeviceType = deviceType;
            //        deviceObj.AuthorizationToken = Token;
            //        deviceObj.UpdatedOn = DateTime.UtcNow;
            //        deviceObj.TimezoneOffsetInSeconds = TimezoneOffsetInSeconds;
            //        _context.UserDeviceInfos.Update(deviceObj);
            //    }
            //    else
            //    {
            //        UserDeviceInfoEntity obj = new UserDeviceInfoEntity()
            //        {
            //            DeviceToken = deviceToken,
            //            DeviceType = deviceType,
            //            UserId = userId,
            //            AuthorizationToken = Token,
            //            CreatedOn = DateTime.UtcNow,
            //            TimezoneOffsetInSeconds = TimezoneOffsetInSeconds
            //        };
            //        _context.UserDeviceInfos.Add(obj);
            //    }

            //    _context.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    ex.Log();
            //    throw ex;
            //}
        }


        public ApiResponses<bool> Logout(string userId)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var deviceInfo = _context.UserDeviceInfos.Where(x => x.UserId == userId).FirstOrDefault();
            //    if (deviceInfo != null)
            //    {
            //        //update user device info
            //        deviceInfo.AuthorizationToken = "";
            //        deviceInfo.DeviceToken = "";
            //        deviceInfo.DeviceType = 0;
            //        deviceInfo.UpdatedOn = DateTime.Now.GetLocal();
            //        _context.UserDeviceInfos.Update(deviceInfo);
            //        _context.SaveChanges();

            //        return new ApiResponses<bool>(ResponseMsg.Ok, true, _errors, successMsg: ResponseStatus.LogOutSucessfully, apiName: "Logout");
            //    }
            //    else
            //    {
            //        return new ApiResponses<bool>(ResponseMsg.Error, false, _errors, failureMsg: ResponseStatus.FailedToLogout, apiName: "Logout");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.Log();
            //    return new ApiResponses<bool>(ResponseMsg.Error, false, _errors, failureMsg: ResponseStatus.FailedToLogout, apiName: "Logout");
            //}
        }
        public void UpdateUserToken(string userId, string Token)
        {
            //try
            //{
            //    var deviceObj = _context.UserDeviceInfos.FirstOrDefault(x => x.UserId == userId);
            //    if (deviceObj != null)
            //    {
            //        deviceObj.DeviceToken = Token;
            //        deviceObj.AuthorizationToken = Token;
            //        deviceObj.UpdatedOn = DateTime.UtcNow;
            //        _context.UserDeviceInfos.Update(deviceObj);
            //        _context.SaveChanges();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public async Task<bool> SaveToken(string userId, string token, bool isUpdate)
        {
            throw new NotImplementedException();
            //var user = await base.FindByIdAsync(userId);
            //if (user != null)
            //{
            //    if (isUpdate)
            //    {
            //        user.ResetToken = "";
            //    }
            //    else
            //    {
            //        user.ResetToken = token;
            //    }

            //    user.ModifiedDate = DateTime.UtcNow;
            //    await base.UpdateAsync(user);
            //    return true;
            //}
            //else { return false; }
        }

        public void Dispose()
        {

        }
        #region All old gen

        public Task<string> GeneratePasswordResetTokenAsync(long user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(long user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public string GetUserId(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailConfirmedAsync(long user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(long user, string role)
        {
            return Task.Run(()=> { return true; });
        }

        public Task<CustomIdentityResult> ResetPasswordAsync(long user, string token, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveToken(long userId, string token, bool isUpdate)
        {
            throw new NotImplementedException();
        }

        #endregion
        #endregion
    }
}
