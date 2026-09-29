using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.DetainLicense
{
    public class DetainLicenseDto
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

        public DetainLicenseDto()
        {
            DetainId = -1;
            LicenseId = -1;
            DetainDate = DateTime.Now;
            IsReleased = false;
            DetainFees = 0;
            ReleaseDate = DateTime.Now;
            NationalNo = string.Empty;
            FullName = string.Empty;
            ReleaseAppId = -1;
        }
    }
}
