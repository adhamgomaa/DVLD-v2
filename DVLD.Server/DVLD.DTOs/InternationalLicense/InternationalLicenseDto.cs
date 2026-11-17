namespace DVLD.DTOs.InternationalLicense;
    public class InternationalLicenseDto
    {
        public int InternationalID { get; set; }
        public int AppID { get; set; }
        public int DriverID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int UserID { get; set; }
        public int LocalLicenseID { get; set; }
    }

