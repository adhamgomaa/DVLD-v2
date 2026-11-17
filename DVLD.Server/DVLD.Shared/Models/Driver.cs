using System;
using System.Collections.Generic;

namespace DVLD.Shared.Models;

public partial class Driver
{
    public int DriverId { get; set; }

    public int PersonId { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public User CreatedByUser { get; set; } = null!;

    public ICollection<InternationalLicense> InternationalLicenses { get; set; } = new List<InternationalLicense>();

    public ICollection<License> Licenses { get; set; } = new List<License>();

    public Person Person { get; set; } = null!;
}
