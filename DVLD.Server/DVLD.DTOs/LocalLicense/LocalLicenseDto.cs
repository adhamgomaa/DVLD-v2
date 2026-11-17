namespace DVLD.DTOs.LocalLicense;

public class LocalLicenseDto
{
    public int AppId { get; set; }
    public required string ClassName { get; set; }
    public required string NationalNo { get; set; }
    public string? FullName { get; set; }
    public DateTime AppDate { get; set; }
    public int? PassedTest { get; set; }
    public string? Status { get; set; }
}

