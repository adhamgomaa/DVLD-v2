using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.Business.Implementations
{
    public sealed class TestAppointmentService(ITestAppointmentData testAppointmentData) : ITestAppointmentService
    {
        public async Task<bool> AddNewAppointmentAsync(TestAppointment newAppointment, CancellationToken cancellationToken)
        {
            await testAppointmentData.AddNewAppointmentAsync(newAppointment, cancellationToken);
            return newAppointment.TestAppointmentId != -1;
        }
        public Task<bool> UpdateAppointmentAsync(TestAppointment updateAppointment, CancellationToken cancellationToken) =>
            testAppointmentData.UpdateAppointmentAsync(updateAppointment, cancellationToken);

        public Task<List<TestAppointment>> GetAllAppointmentAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken) =>
            testAppointmentData.GetAllAppointmentAsync(localId, typeId, cancellationToken);

        public Task<int> GetTrialsAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken) =>
            testAppointmentData.GetTrialsAsync(localId, typeId, cancellationToken);

        public Task<TestAppointment?> FindAppointmentAsync(int appointmentId, CancellationToken cancellationToken) =>
            testAppointmentData.FindAppointmentAsync(appointmentId, cancellationToken);

        public Task<TestAppointment?> GetLastTestAppointmentAsync(int localId, TestTypeEnum testType, CancellationToken cancellationToken) =>
            testAppointmentData.GetLastTestAppointmentAsync(localId, testType, cancellationToken);

        public Task<bool> AppointmentIsLockAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken) =>
            testAppointmentData.AppointmentIsLockAsync(localId, typeId, cancellationToken);

        public Task<int> GetTestIdAsync(int appointmentId, CancellationToken cancellationToken) =>
            testAppointmentData.GetTestIDAsync(appointmentId, cancellationToken);

    }
}
