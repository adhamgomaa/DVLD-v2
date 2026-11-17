namespace DVLD.DTOs.DetainLicense;

public class DetainLicenseDto
{
    public int DetainId { get; set; }
    public int LicenseId { get; set; }
    public DateTime DetainDate { get; set; }
    public bool IsReleased { get; set; }
    public decimal DetainFees { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public required string NationalNo { get; set; }
    public required string FullName { get; set; }
    public int? ReleaseAppId { get; set; }
}

