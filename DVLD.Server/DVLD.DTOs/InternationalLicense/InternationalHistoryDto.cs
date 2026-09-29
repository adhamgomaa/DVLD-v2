using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.InternationalLicense
{
    public class InternationalHistoryDto
    {
        public int InternationalID { get; set; }
        public int AppID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int UserID { get; set; }
        public int LocalLicenseID { get; set; }

        public InternationalHistoryDto()
        {
            InternationalID = -1;
            AppID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            UserID = -1;
            LocalLicenseID = -1;
        }
    }
}
