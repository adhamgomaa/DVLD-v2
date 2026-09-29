using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.DetainLicense
{
    public class UpdateDetainLicenseDto
    {
        [Required]
        public int LicenseID { get; set; }
        [Required]
        public decimal Fees { get; set; }
        [Required]
        public DateTime DetainDate { get; set; }
        [Required]
        public int UserID { get; set; }
        public UpdateDetainLicenseDto()
        {
            LicenseID = -1;
            Fees = 0;
            UserID = -1;
            DetainDate = DateTime.Now;
        }
    }
}
