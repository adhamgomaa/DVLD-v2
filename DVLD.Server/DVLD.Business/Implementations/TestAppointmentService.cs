using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DVLD.Business.Implementations
{
    public sealed class TestAppointmentService(ITestAppointmentData testAppointmentData) : ITestAppointmentService
    {
        public async Task<bool> AddNewAppointmentAsync(TestAppointment newAppointment, CancellationToken cancellationToken)
        {
            newAppointment.AppointmentId = await testAppointmentData.AddNewAppointmentAsync(newAppointment, cancellationToken);
            return newAppointment.AppointmentId != -1;
        }
        public async Task<bool> UpdateAppointmentAsync(TestAppointment updateAppointment, CancellationToken cancellationToken)
        {
            return await testAppointmentData.UpdateAppointmentAsync(updateAppointment, cancellationToken);
        }

        public async Task<List<TestAppointment>> GetAllAppointmentAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken)
        {
            return await testAppointmentData.GetAllAppointmentAsync(localId, typeId, cancellationToken);
        }

        public async Task<int> GetTrialsAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken)
        {
            return await testAppointmentData.GetTrialsAsync(localId, typeId, cancellationToken);
        }

        public async Task<TestAppointment?> FindAppointmentAsync(int appointmentId, CancellationToken cancellationToken)
        {
            TestAppointment? appointment = await testAppointmentData.FindAppointmentAsync(appointmentId, cancellationToken);
            if (appointment != null)
                return appointment;
            return null;
        }

        public async Task<TestAppointment?> GetLastTestAppointmentAsync(int localId, TestTypeEnum testType, CancellationToken cancellationToken)
        {
            TestAppointment? appointment = await testAppointmentData.GetLastTestAppointmentAsync(localId, testType, cancellationToken);
            if (appointment != null)
                return appointment;
            return null;
        }

        public async Task<bool> AppointmentIsLockAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken)
        {
            return await testAppointmentData.AppointmentIsLockAsync(localId, typeId, cancellationToken);
        }

        public async Task<int> GetTestIdAsync(int appointmentId, CancellationToken cancellationToken)
        {
            return await testAppointmentData.GetTestIDAsync(appointmentId, cancellationToken);
        }

    }
}
