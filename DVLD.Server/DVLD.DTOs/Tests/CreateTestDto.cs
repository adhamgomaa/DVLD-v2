using System.ComponentModel.DataAnnotations;
namespace DVLD.DTOs.Tests;

public class CreateTestDto
{
    [Required]
    public int AppointmentID { get; set; }
    [Required]
    public bool Result { get; set; }
    public string? Notes { get; set; }
    [Required]
    public int UserId { get; set; }
}

