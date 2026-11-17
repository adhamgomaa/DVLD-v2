using DVLD.DTOs.Applications;
using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.InternationalLicense;
    public class CreateInternationalLicenseDto : CreateAppDto
    {
        [Required]
        public int DriverID { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int LocalLicenseID { get; set; }
    }
