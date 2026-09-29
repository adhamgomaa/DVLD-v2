using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Tests
{
    public class TestDto
    {
        public int TestId { get; set; }
        public int AppointmentID { get; set; }
        public bool Result { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }

        public TestDto()
        {
            TestId = -1;
            AppointmentID = -1;
            Result = false;
            Notes = string.Empty;
            UserId = -1;
        }
    }
}
