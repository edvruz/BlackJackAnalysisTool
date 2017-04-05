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
            throw new System.NotImplementedException();
        }

        public bool IsUserCredentialsValid(string loginName, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}