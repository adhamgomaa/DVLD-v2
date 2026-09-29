using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.LocalLicense
{
    public class GetLocalLicenseDto
    {
        public int LocalId { get; set; }
        public int AppId { get; set; }
        public int ClassId { get; set; }

        public GetLocalLicenseDto()
        {
            LocalId = -1;
            ClassId = -1;
            AppId = -1;
        }
    }
}
