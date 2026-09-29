using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class Test
    {
        public int TestId { get; set; }
        public int AppointmentID { get; set; }
        public bool Result { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }

        public Test()
        {
            TestId = -1;
            AppointmentID = -1;
            Result = false;
            Notes = string.Empty;
            UserId = -1;
        }

        public Test(int testId, int appointmentId, bool result, string notes, int userId)
        {
            TestId = testId;
            AppointmentID = appointmentId;
            Result = result;
            Notes = notes;
            UserId = userId;
        }

    }
}
