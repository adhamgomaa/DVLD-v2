using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Tests
{
    public class CreateTestDto
    {
        [Required]
        public int AppointmentID { get; set; }
        [Required]
        public bool Result { get; set; }
        public string Notes { get; set; }
        [Required]
        public int UserId { get; set; }

        public CreateTestDto()
        {
            AppointmentID = -1;
            Result = false;
            Notes = string.Empty;
            UserId = -1;
        }
    }
}
