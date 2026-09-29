using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.DetainLicense
{
    public class GetDetainDto
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal Fees { get; set; }
        public int UserID { get; set; }
        public bool IsRelease { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleaseByUserId { get; set; }
        public int ReleaseAppId { get; set; }
        public GetDetainDto()
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
    }
}
