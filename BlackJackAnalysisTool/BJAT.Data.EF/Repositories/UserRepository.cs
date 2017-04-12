using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BJAT.Common.Enums;
using BJAT.Data.Entities;
using BJAT.Data.Repositories;

namespace BJAT.Data.EF.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public AppContext Repo => Context as AppContext;

        public UserRepository(AppContext context) : base(context)
        {
        }
        
        public IEnumerable<User> GetUsersByStatus(UserStatusEnum status)
        {
            return Repo.Users.Where(x => x.Status.Equals(status));
        }

        public User GetUserByLoginNameOrEmail(string loginNameOrEmail)
        {
            return Repo.Users
                .SingleOrDefault(x => x.LoginName.Equals(loginNameOrEmail) || x.Email.Equals(loginNameOrEmail));
        }

        public IEnumerable<User> GetUsersByRole(UserRoleEnum role)
        {
            return Repo.Users.Where(x => x.Role.Equals(role));
        }
    }
}