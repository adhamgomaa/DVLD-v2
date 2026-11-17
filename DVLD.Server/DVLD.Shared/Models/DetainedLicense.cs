using System;
using System.Collections.Generic;

namespace DVLD.Shared.Models;

public partial class DetainedLicense
{
    public int DetainId { get; set; }

    public int LicenseId { get; set; }

    public DateTime DetainDate { get; set; }

    public decimal DetainFees { get; set; }

    public int CreatedByUserId { get; set; }

    public bool IsReleased { get; set; }

    public DateTime? ReleaseDate { get; set; } = null;

    public int? ReleasedByUserId { get; set; }

    public int? ReleaseApplicationId { get; set; }

    public User CreatedByUser { get; set; } = null!;

    public License License { get; set; } = null!;

    public Application? ReleaseApplication { get; set; }

    public User? ReleasedByUser { get; set; }
}
