using System;
using System.Collections.Generic;

namespace DVLD.Shared.Models;

public partial class LocalDrivingLicenseApplication
{
    public int LDLAppId { get; set; }

    public string DrivingClass { get; set; } = null!;

    public string NationalNo { get; set; } = null!;

    public string? FullName { get; set; }

    public DateTime ApplicationDate { get; set; }

    public int? PassedTests { get; set; }

    public string? Status { get; set; }
}
