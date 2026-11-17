using DVLD.Shared.Enums;

namespace DVLD.DTOs.Licenses;

    public class GetLicenseDto
    {
        public int LicenseID { get; set; }
        public int DriverID { get; set; }
        public int AppID { get; set; }
        public int ClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public decimal Fees { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
        public IssueReasonEnum IssueReason { get; set; }
        public int UserID { get; set; }
    }

