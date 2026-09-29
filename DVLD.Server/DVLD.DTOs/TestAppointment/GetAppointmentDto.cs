using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.TestAppointment
{
    public class GetAppointmentDto
    {
        public int AppointmentId { get; set; }
        public TestTypeEnum TestTypeId { get; set; }
        public int LocalId { get; set; }
        public DateTime Date { get; set; }
        public decimal Fees { get; set; }
        public int UserId { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeApplicationId { get; set; }

        public GetAppointmentDto()
        {
            AppointmentId = -1;
            TestTypeId = TestTypeEnum.VisionTest;
            LocalId = -1;
            Date = DateTime.Now;
            Fees = 0;
            UserId = -1;
            IsLocked = false;
            RetakeApplicationId = -1;
        }
    }
}
