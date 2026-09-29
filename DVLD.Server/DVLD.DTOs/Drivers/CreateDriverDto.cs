using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Drivers
{
    public class CreateDriverDto
    {
        [Required]
        public int PersonID { get; set; }
        [Required]
        public int UserID { get; set; }

        public CreateDriverDto()
        {
            PersonID = -1;
            UserID = -1;
        }
    }
}
