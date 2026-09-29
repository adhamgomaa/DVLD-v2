using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class InternationalLicense : Application
    {
        public int InternationalID { get; set; }
        public new int AppID { get; set; }
        public int DriverID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int UserID { get; set; }
        public int LocalLicenseID { get; set; }

        public InternationalLicense()
        {
            InternationalID = -1;
            AppID = -1;
            DriverID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            UserID = -1;
            LocalLicenseID = -1;
        }

        public InternationalLicense(int internationalId, int driverId, DateTime issue, DateTime expired, bool isActive, int localId, int appID, int userID)
        {
            InternationalID = internationalId;
            DriverID = driverId;
            IssueDate = issue;
            ExpirationDate = expired;
            IsActive = isActive;
            LocalLicenseID = localId;
            AppID = appID;
            UserID = userID;
        }
        public InternationalLicense(int internationalId, DateTime issue, DateTime expired, bool isActive, int localId, int appID, int userID)
        {
            InternationalID = internationalId;
            IssueDate = issue;
            ExpirationDate = expired;
            IsActive = isActive;
            LocalLicenseID = localId;
            AppID = appID;
            UserID = userID;
        }
    }
}
