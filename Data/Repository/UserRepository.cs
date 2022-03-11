using Dapper;
using Data.IFactory;
using Data.IRepository;
using Shared.Common.Enums;
using Shared.Models.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly string selectUserQuery = @"SELECT * FROM dbo.[User]";


        private readonly IDbConnectionFactory _dbConnection;



        public UserRepository(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<CustomIdentityResult> AddToRolesAsync(long userId, string[] roles)
        {
            throw new NotImplementedException();
        }

        public Task<CustomIdentityResult> ChangePasswordAsync(long userId, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckPasswordAsync(long userId, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            string Query = selectUserQuery + @" WHERE Email = @Email";

            User user;
            using (IDbConnection connection = _dbConnection.CreateDBConnection())
            {
                var users = await connection.QueryAsync<User>(
                    Query, new
                    {
                        Email = email
                    }, commandType: CommandType.Text);

                user = users.ToList().FirstOrDefault();
            }
            return user;
        }

        public async Task<SignInResult> PasswordSignInAsync(string email, string password, bool isPersistent, bool lockoutOnFailure)
        {
            string Query = selectUserQuery + @" WHERE Email = @Email and PasswordHash=@Password";

            SignInResult result=new();
            using (IDbConnection connection = _dbConnection.CreateDBConnection())
            {
                var users = await connection.QueryAsync<User>(
                    Query, new
                    {
                        Email = email,
                        Password=password
                    }, commandType: CommandType.Text);

                if(users.FirstOrDefault()!=null && users.FirstOrDefault().Id>0 )
                {
                    result.Succeeded = true;
                    result.User = users.FirstOrDefault();
                }
                else
                {
                    result.Succeeded = false;
                    result.Message = ResponseMsg.IncorrectUserLogin.ToString();
                }
            }
            return result;
        }
    }
}
