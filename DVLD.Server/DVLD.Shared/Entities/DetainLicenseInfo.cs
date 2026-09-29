using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class DetainLicenseInfo
    {
        public int DetainId { get; set; }
        public int LicenseId { get; set; }
        public DateTime DetainDate { get; set; }
        public bool IsReleased { get; set; }
        public decimal DetainFees { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public int ReleaseAppId { get; set; }

        public DetainLicenseInfo(int detainId, int licenseId, DateTime detainDate, bool isReleased, decimal detainFees, DateTime releaseDate, string nationalNo, string fullName, int releaseAppId)
        {
            DetainId = detainId;
            LicenseId = licenseId;
            DetainDate = detainDate;
            IsReleased = isReleased;
            DetainFees = detainFees;
            ReleaseDate = releaseDate;
            NationalNo = nationalNo;
            FullName = fullName;
            ReleaseAppId = releaseAppId;
        }
    }
}
