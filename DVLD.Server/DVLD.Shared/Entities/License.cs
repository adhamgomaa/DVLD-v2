using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class License
    {
        public int LicenseID { get; set; }
        public int DriverID { get; set; }
        public int AppID { get; set; }
        public int ClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public decimal Fees { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public IssueReasonEnum IssueReason { get; set; }
        public int UserID { get; set; }

        public License()
        {
            LicenseID = -1;
            DriverID = -1;
            AppID = -1;
            ClassID = -1;
            IssueDate = DateTime.Now;
            ExpiredDate = IssueDate;
            Fees = 0;
            Notes = string.Empty;
            IsActive = false;
            IssueReason = IssueReasonEnum.FirstTime;
            UserID = -1;
        }

        public License(int licenseID, int driverID, int appID, int classID, DateTime issueDate, DateTime expiredDate, decimal fees, string notes, bool isActive, IssueReasonEnum issueReason, int userID)
        {
            LicenseID = licenseID;
            DriverID = driverID;
            AppID = appID;
            ClassID = classID;
            IssueDate = issueDate;
            ExpiredDate = expiredDate;
            Fees = fees;
            Notes = notes;
            IsActive = isActive;
            IssueReason = issueReason;
            UserID = userID;
        }
    }
}
