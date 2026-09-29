using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Users
{
    public class UserInfoDto
    {
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }

        public UserInfoDto()
        {
            UserId = -1;
            PersonId = -1;
            FullName = string.Empty;
            UserName = string.Empty;
            IsActive = false;
        }
    }
}
