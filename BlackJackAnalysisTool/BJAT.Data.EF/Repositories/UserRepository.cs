using System.Collections.Generic;
using System.Data.Entity;
using BJAT.Common.Enums;
using BJAT.Data.Entities;
using BJAT.Data.Repositories;

namespace BJAT.Data.EF.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User GetUserByLoginName(string loginName)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetUsersByStatus(UserStatusEnum status)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetUsersByRole(UserRoleEnum role)
        {
            throw new System.NotImplementedException();
        }
    }
}