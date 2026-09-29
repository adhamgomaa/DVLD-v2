using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public User()
        {
            UserId = -1;
            PersonId = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
        }

        public User(int id, int personId, string username, string password, bool isActive)
        {
            UserId = id;
            PersonId = personId;
            UserName = username;
            Password = password;
            IsActive = isActive;
        }
    }
}
