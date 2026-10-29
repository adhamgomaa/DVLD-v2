using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface ITestAppointmentService
{
    Task<bool> AddNewAppointmentAsync(TestAppointment newAppointment, CancellationToken cancellationToken);
    Task<bool> UpdateAppointmentAsync(TestAppointment updateAppointment, CancellationToken cancellationToken);
    Task<List<TestAppointment>> GetAllAppointmentAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken);
    Task<int> GetTrialsAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken);
    Task<TestAppointment?> FindAppointmentAsync(int appointmentId, CancellationToken cancellationToken);
    Task<TestAppointment?> GetLastTestAppointmentAsync(int localId, TestTypeEnum testType, CancellationToken cancellationToken);
    Task<bool> AppointmentIsLockAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken);
    Task<int> GetTestIdAsync(int appointmentId, CancellationToken cancellationToken);
}
