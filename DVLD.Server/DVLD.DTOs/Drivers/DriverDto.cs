namespace DVLD.DTOs.Drivers;

public class DriverDto
{
    public int DriverId { get; set; }
    public int PersonId { get; set; }
    public required string NationalNo { get; set; }
    public string? FullName { get; set; }
    public DateTime Date { get; set; }
    public int? ActiveLicense { get; set; }
}

