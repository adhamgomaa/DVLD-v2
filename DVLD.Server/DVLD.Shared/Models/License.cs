using System;
using System.Collections.Generic;
using DVLD.Shared.Enums;

namespace DVLD.Shared.Models;

public partial class License
{
    public int LicenseId { get; set; }

    public int DriverId { get; set; }

    public int ApplicationId { get; set; }

    public int LicenseClassId { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public decimal PaidFees { get; set; }

    public string? Notes { get; set; }

    public bool IsActive { get; set; }

    /// <summary>
    /// 1-FirstTime, 2-Renew, 3-Replacement for a Damaged, 4- Replacement for a Lost
    /// </summary>
    public IssueReasonEnum IssueReason { get; set; }

    public int CreatedByUserId { get; set; }

    public Application Application { get; set; } = null!;

    public User CreatedByUser { get; set; } = null!;

    public ICollection<DetainedLicense> DetainedLicenses { get; set; } = new List<DetainedLicense>();

    public Driver Driver { get; set; } = null!;

    public ICollection<InternationalLicense> InternationalLicenses { get; set; } = new List<InternationalLicense>();

    public LicenseClass LicenseClass { get; set; } = null!;
}
