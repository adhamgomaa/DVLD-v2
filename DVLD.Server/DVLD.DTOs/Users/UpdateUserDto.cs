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
        public required string UserName { get; set; }
        [MaxLength(128)]
        public required string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
