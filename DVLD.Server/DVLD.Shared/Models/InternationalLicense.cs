using System;
using System.Collections.Generic;

namespace DVLD.Shared.Models;

public partial class InternationalLicense
{
    public int InternationalLicenseId { get; set; }

    public int ApplicationId { get; set; }

    public int DriverId { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public int CreatedByUserId { get; set; }

    public bool IsActive { get; set; }

    public int IssuedUsingLocalLicenseId { get; set; }

    public Application Application { get; set; } = null!;

    public User CreatedByUser { get; set; } = null!;

    public Driver Driver { get; set; } = null!;

    public License IssuedUsingLocalLicense { get; set; } = null!;
}
