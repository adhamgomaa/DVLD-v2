using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.TestAppointment
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Fees { get; set; }
        public bool IsLocked { get; set; }

        public AppointmentDto()
        {
            AppointmentId = -1;
            Date = DateTime.Now;
            Fees = 0;
            IsLocked = false;
        }
    }
}
