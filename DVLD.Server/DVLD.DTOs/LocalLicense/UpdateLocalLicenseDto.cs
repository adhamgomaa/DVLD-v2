using DVLD.DTOs.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.LocalLicense
{
    public class UpdateLocalLicenseDto : UpdateAppDto
    {
        [Required]
        public int ClassId { get; set; }
        public UpdateLocalLicenseDto()
        {
            ClassId = -1;
            
        }
    }
}
