using System;
using BJAT.Common.Enums;

namespace BJAT.Data.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string LoginName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public UserRoleEnum Role { get; set; }
        public DateTime LastLogin { get; set; }
        public int FailedAttemptsToConnect { get; set; }
        public UserStatusEnum Status { get; set; }
    }
}