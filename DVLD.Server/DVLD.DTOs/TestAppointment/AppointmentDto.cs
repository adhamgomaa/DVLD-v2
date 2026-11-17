namespace DVLD.DTOs.TestAppointment;

public class AppointmentDto
{
    public int AppointmentId { get; set; }
    public DateTime Date { get; set; }
    public decimal Fees { get; set; }
    public bool IsLocked { get; set; }
}

