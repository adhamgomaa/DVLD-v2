using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class TestAppointment
    {
        public int AppointmentId { get; set; }
        public TestTypeEnum TestTypeId { get; set; }
        public int LocalId { get; set; }
        public DateTime Date { get; set; }
        public decimal Fees { get; set; }
        public int UserId { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeApplicationId { get; set; }

        public TestAppointment()
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

        public TestAppointment(int appointmentId, TestTypeEnum testTypeId, int localId, DateTime date, decimal fees, int userId, bool isLocked, int retake)
        {
            AppointmentId = appointmentId;
            TestTypeId = testTypeId;
            LocalId = localId;
            Date = date;
            Fees = fees;
            UserId = userId;
            IsLocked = isLocked;
            RetakeApplicationId = retake;
        }

        public TestAppointment(int appointmentId, DateTime date, decimal fees, bool isLocked)
        {
            AppointmentId = appointmentId;
            Date = date;
            Fees = fees;
            IsLocked = isLocked;
        }
    }
}
