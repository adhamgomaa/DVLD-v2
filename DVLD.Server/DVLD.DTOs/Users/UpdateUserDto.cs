using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Users
{
    public class UpdateUserDto
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public UpdateUserDto()
        {
            this.PersonId = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;
        }
    }
}
