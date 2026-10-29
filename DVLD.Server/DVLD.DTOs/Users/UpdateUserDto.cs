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
        [Range(1, int.MaxValue)]
        public int PersonId { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(128)]
        public string Password { get; set; }
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
