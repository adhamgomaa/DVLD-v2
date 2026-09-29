using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.TestAppointment
{
    public class UpdateAppointmentDto
    {
        [Required]
        public TestTypeEnum TestTypeId { get; set; }
        [Required]
        public int LocalId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Fees { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public bool IsLocked { get; set; }

        public UpdateAppointmentDto()
        {
            TestTypeId = TestTypeEnum.VisionTest;
            LocalId = -1;
            Date = DateTime.Now;
            Fees = 0;
            UserId = -1;
            IsLocked = false;
        }
    }
}
