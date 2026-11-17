using DVLD.Shared.Enums;
namespace DVLD.DTOs.TestAppointment;

    public class GetAppointmentDto
    {
        public int AppointmentId { get; set; }
        public TestTypeEnum TestTypeId { get; set; }
        public int LocalId { get; set; }
        public DateTime Date { get; set; }
        public decimal Fees { get; set; }
        public int UserId { get; set; }
        public bool IsLocked { get; set; }
        public int? RetakeApplicationId { get; set; }
    }
