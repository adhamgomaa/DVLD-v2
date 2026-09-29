using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.LocalLicense
{
    public class LocalLicenseDto
    {
        public int AppId { get; set; }
        public string ClassName { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public DateTime AppDate { get; set; }
        public int PassedTest { get; set; }
        public string Status { get; set; }

        public LocalLicenseDto()
        {
            AppId = -1;
            ClassName = string.Empty;
            NationalNo = string.Empty;
            FullName = string.Empty;
            AppDate = DateTime.Now;
            PassedTest = 0;
            Status = string.Empty;
        }
    }
}
