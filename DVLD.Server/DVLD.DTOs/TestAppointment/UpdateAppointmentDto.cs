using DVLD.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.TestAppointment;

public class UpdateAppointmentDto
{
    [Required]
    public TestTypeEnum TestTypeId { get; set; }
    [Required]
    public int LocalId { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public decimal Fees { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public bool IsLocked { get; set; }
}

