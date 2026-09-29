using DVLD.DTOs.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.LocalLicense
{
    public class CreateLocalLicenseDto : CreateAppDto
    {
        [Required]
        public int ClassId { get; set; }
        public CreateLocalLicenseDto()
        {
            ClassId = -1;
        }
    }
}
