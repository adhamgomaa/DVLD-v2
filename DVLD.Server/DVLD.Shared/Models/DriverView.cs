using System;
using System.Collections.Generic;

namespace DVLD.Shared.Models;

public partial class DriverView
{
    public int DriverId { get; set; }

    public int PersonId { get; set; }

    public string NationalNo { get; set; } = null!;

    public string? FullName { get; set; }

    public DateTime Date { get; set; }

    public int? ActiveLicenses { get; set; }
}
