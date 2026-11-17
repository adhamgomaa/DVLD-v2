using DVLD.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.Licenses;

    public class UpdateLicenseDto
    {
        [Required]
        public int DriverID { get; set; }
        [Required]
        public int AppID { get; set; }
        [Required]
        public int ClassID { get; set; }
        [Required]
        public DateTime ExpiredDate { get; set; }
        [Required]
        public decimal Fees { get; set; }
        public string? Notes { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public IssueReasonEnum IssueReason { get; set; }
        [Required]
        public int UserID { get; set; }
    }

