using System.ComponentModel.DataAnnotations;
namespace DVLD.DTOs.DetainLicense;
    public class CreateDetainLicenseDto
    {
        [Required]
        public int LicenseID { get; set; }
        [Required]
        public decimal Fees { get; set; }
        [Required]
        public int UserID { get; set; }
    }
