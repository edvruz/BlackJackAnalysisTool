using System.Collections;
using System.Collections.Generic;
using BJAT.Common.Enums;
using BJAT.Data.Entities;

namespace BJAT.Services.Contracts
{
    public interface IUserService
    {
        bool RegisterUser(User user);
        bool IsUserCredentialsValid(string loginNameOrEmail, string password);
        bool IsUserNameAndEmailAvailable(string username, string email);
        void FailedToLogin(string userNameOrEmail);
        void LoginSuccesfull(string userNameOrEmail);
    }
}