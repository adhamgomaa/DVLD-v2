using System;

namespace DVLD.Shared.Models;

public partial class DetainedLicenseInfo
{
    public int DetainId { get; set; }

    public int LicenseId { get; set; }

    public DateTime DetainDate { get; set; }

    public decimal DetainFees { get; set; }

    public bool IsReleased { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public int? ReleaseApplicationId { get; set; }

    public required string FullName {get; set;}
    
    public required string NationalNo {get; set;}
}
