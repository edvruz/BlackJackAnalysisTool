using System;
using System.Linq;
using BJAT.Common.Enums;
using BJAT.Data;
using BJAT.Data.Entities;
using BJAT.Services.Contracts;

namespace BJAT.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        





        public bool RegisterUser(User user)
        {
            try
            {
                if (IsUserNameAndEmailAvailable(user.LoginName, user.Email))
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    user.UserId = Guid.NewGuid();
                    user.Role = UserRoleEnum.User;
                    user.Status = UserStatusEnum.Active;
                    user.FailedAttemptsToConnect = 0;
                    user.LastLogin = DateTime.Now;
                    user.PasswordHash = crypto.Compute(user.PasswordHash);
                    user.PasswordSalt = crypto.Salt;
                    _unitOfWork.Users.Add(user);
                    _unitOfWork.Complete();
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool IsUserCredentialsValid(string loginNameOrEmail, string password)
        {
            var user = _unitOfWork.Users.GetUserByLoginNameOrEmail(loginNameOrEmail);

            if (user == null) return false;

            var crypto = new SimpleCrypto.PBKDF2();
            return user.PasswordHash == crypto.Compute(password, user.PasswordSalt);
        }

        public bool IsUserNameAndEmailAvailable(string username, string email)
        {
            return !_unitOfWork.Users.Find(x => x.LoginName == username || x.Email == email).Any();
        }

        public void FailedToLogin(string userNameOrEmail)
        {
            var user = _unitOfWork.Users.GetUserByLoginNameOrEmail(userNameOrEmail);
            user.FailedAttemptsToConnect += 1;
            _unitOfWork.Complete();
        }

        public void LoginSuccesfull(string userNameOrEmail)
        {
            var user = _unitOfWork.Users.GetUserByLoginNameOrEmail(userNameOrEmail);
            user.LastLogin = DateTime.Now;
            user.FailedAttemptsToConnect = 0;
            _unitOfWork.Complete();
        }
    }
}