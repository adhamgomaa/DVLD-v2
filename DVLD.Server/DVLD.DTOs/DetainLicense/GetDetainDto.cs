namespace DVLD.DTOs.DetainLicense;
    public class GetDetainDto
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal Fees { get; set; }
        public int UserID { get; set; }
        public bool IsRelease { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleaseByUserId { get; set; }
        public int? ReleaseAppId { get; set; }
    }
