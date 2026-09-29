using DVLD.DTOs.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.InternationalLicense
{
    public class CreateInternationalLicenseDto : CreateAppDto
    {
        [Required]
        public int DriverID { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int LocalLicenseID { get; set; }

        public CreateInternationalLicenseDto()
        {
            DriverID = -1;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            UserID = -1;
            LocalLicenseID = -1;
        }
    }
}
