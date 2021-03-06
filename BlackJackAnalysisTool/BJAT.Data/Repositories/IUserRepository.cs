﻿using System.Collections.Generic;
using BJAT.Common.Enums;
using BJAT.Data.Entities;

namespace BJAT.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByLoginNameOrEmail(string loginNameOrEmail);
        IEnumerable<User> GetUsersByRole(UserRoleEnum role);
        IEnumerable<User> GetUsersByStatus(UserStatusEnum status);
    }
}