using System;
using System.Collections.Generic;

namespace DVLD.Shared.Models;

public partial class LicenseClass
{
    public int LicenseClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public string ClassDescription { get; set; } = null!;

    public int MinimumAllowedAge { get; set; }

    public int DefaultValidityLength { get; set; }

    public decimal ClassFees { get; set; }

    public ICollection<License> Licenses { get; set; } = new List<License>();

    public ICollection<LocalDrivingLicense> LocalDrivingLicenses { get; set; } = new List<LocalDrivingLicense>();
}
