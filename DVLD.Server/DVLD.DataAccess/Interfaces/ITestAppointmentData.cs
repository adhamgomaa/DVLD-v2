using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface ITestAppointmentData
{
    Task<List<TestAppointment>> GetAllAppointmentAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken);
    Task<int> AddNewAppointmentAsync(TestAppointment newAppointment, CancellationToken cancellationToken);
    Task<bool> UpdateAppointmentAsync(TestAppointment updateAppointment, CancellationToken cancellationToken);
    Task<TestAppointment?> FindAppointmentAsync(int appId, CancellationToken cancellationToken);
    Task<TestAppointment?> GetLastTestAppointmentAsync(int localId, TestTypeEnum testType, CancellationToken cancellationToken);
    Task<int> GetTrialsAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken);
    Task<bool> AppointmentIsLockAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken);
    Task<int> GetTestIDAsync(int testAppointmentID, CancellationToken cancellationToken);
}
