using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Users
{
    public class GetUserDto
    {
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }

        public GetUserDto()
        {
            this.UserId = -1;
            this.PersonId = -1;
            this.UserName = string.Empty;
            this.IsActive = false;
        }
    }
}
