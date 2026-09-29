using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Licenses
{
    public class LicenseHistoryDto
    {
        public int LicenseID { get; set; }
        public int AppID { get; set; }
        public string ClassName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

        public LicenseHistoryDto()
        {
            LicenseID = -1;
            AppID = -1;
            ClassName = string.Empty;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
        }
    }
}
