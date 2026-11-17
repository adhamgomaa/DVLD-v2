using DVLD.DTOs.Applications;
using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.LocalLicense;

    public class CreateLocalLicenseDto : CreateAppDto
    {
        [Required]
        public int ClassId { get; set; }
    }

