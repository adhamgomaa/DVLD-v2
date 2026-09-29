using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }

        public UserInfo(int userId, int personId, string fullName, string userName, bool isActive)
        {
            UserId = userId;
            PersonId = personId;
            FullName = fullName;
            UserName = userName;
            IsActive = isActive;
        }
    }
}
