using System.Collections;
using System.Collections.Generic;
using BJAT.Common.Enums;
using BJAT.Data.Entities;

namespace BJAT.Services.Contracts
{
    public interface IUserService
    {
        bool RegisterUser(User user);
        bool IsUserCredentialsValid(string loginName, string password);
    }
}