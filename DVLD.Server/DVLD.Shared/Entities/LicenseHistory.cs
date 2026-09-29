using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class LicenseHistory
    {
        public int LicenseID { get; set; }
        public int AppID { get; set; }
        public string ClassName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

        public LicenseHistory(int licenseID, int appID, string className, DateTime issueDate, DateTime expirationDate, bool isActive)
        {
            LicenseID = licenseID;
            AppID = appID;
            ClassName = className;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
        }
    }
}
