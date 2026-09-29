using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Drivers
{
    public class DriverDto
    {
        public int DriverId { get; set; }
        public int PersonId { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public int ActiveLicense { get; set; }

        public DriverDto()
        {
            DriverId = -1;
            PersonId = -1;
            NationalNo = string.Empty;
            FullName = string.Empty;
            Date = DateTime.MinValue;
            ActiveLicense = 0;
        }
    }
}
