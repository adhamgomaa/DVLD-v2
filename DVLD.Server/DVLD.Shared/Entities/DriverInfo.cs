using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class DriverInfo
    {
        public int DriverId { get; set; }
        public int PersonId { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public int ActiveLicense { get; set; }

        public DriverInfo(int driverId, int personId, string nationalNo, string fullName, DateTime date, int activeLicense)
        {
            DriverId = driverId;
            PersonId = personId;
            NationalNo = nationalNo;
            FullName = fullName;
            Date = date;
            ActiveLicense = activeLicense;
        }
    }
}
