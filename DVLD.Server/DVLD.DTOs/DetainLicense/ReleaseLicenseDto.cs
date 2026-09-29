using DVLD.DTOs.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.DetainLicense
{
    public class ReleaseLicenseDto : CreateAppDto
    {
        public int ReleaseByUserId { get; set; }
        public int ReleaseAppId { get; set; }

        public ReleaseLicenseDto()
        {
            ReleaseByUserId = -1;
            ReleaseAppId = -1;
        }
    }
}
