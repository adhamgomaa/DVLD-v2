using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.DetainLicense;
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
    }
