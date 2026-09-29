using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class DetainLicense : Application
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public new decimal Fees { get; set; }
        public int UserID { get; set; }
        public bool IsRelease { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleaseByUserId { get; set; }
        public int ReleaseAppId { get; set; }
        public DetainLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            Fees = 0;
            UserID = -1;
            IsRelease = false;
            ReleaseDate = DateTime.MaxValue;
            ReleaseByUserId = -1;
            ReleaseAppId = -1;
        }

        public DetainLicense(int detainID, int licenseID, DateTime detainDate, decimal fees, int userID, bool isRelease,
            DateTime releaseDate, int releaseByUserId, int releaseAppId)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            Fees = fees;
            UserID = userID;
            IsRelease = isRelease;
            ReleaseDate = releaseDate;
            ReleaseByUserId = releaseByUserId;
            ReleaseAppId = releaseAppId;
        }
    }
}
