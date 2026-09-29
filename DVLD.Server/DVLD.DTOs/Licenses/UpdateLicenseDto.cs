using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Licenses
{
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
        public string Notes { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public IssueReasonEnum IssueReason { get; set; }
        [Required]
        public int UserID { get; set; }

        public UpdateLicenseDto()
        {
            DriverID = -1;
            AppID = -1;
            ClassID = -1;
            ExpiredDate = DateTime.Now;
            Fees = 0;
            Notes = string.Empty;
            IsActive = false;
            IssueReason = IssueReasonEnum.FirstTime;
            UserID = -1;
        }
    }
}
