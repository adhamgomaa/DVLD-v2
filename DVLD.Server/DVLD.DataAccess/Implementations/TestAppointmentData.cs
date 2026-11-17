using DVLD.DataAccess.Data;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.DataAccess.Implementations
{
    public sealed class TestAppointmentData(AppDbContext context) : ITestAppointmentData
    {
        public async Task<List<TestAppointment>> GetAllAppointmentAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken)
        {
            var testAppointments = await context.TestAppointments.AsNoTracking()
                        .Where(t => t.LocalDrivingLicense.LocalDrivingLicenseApplicationId == localId &&
                        t.TestTypeId == typeId)
                        .OrderByDescending(t => t.TestAppointmentId)
                        .Select(t => new TestAppointment
                        {
                            TestAppointmentId = t.TestAppointmentId,
                            AppointmentDate = t.AppointmentDate,
                            PaidFees = t.PaidFees,
                            IsLocked = t.IsLocked
                        }).ToListAsync(cancellationToken);
            return testAppointments;
        }

        public async Task<int> AddNewAppointmentAsync(TestAppointment newAppointment, CancellationToken cancellationToken)
        {
            context.TestAppointments.Add(newAppointment);
            await context.SaveChangesAsync(cancellationToken);
            return newAppointment.TestAppointmentId;
        }

        public async Task<bool> UpdateAppointmentAsync(TestAppointment updateAppointment, CancellationToken cancellationToken)
        {
            var testAppointment = await context.TestAppointments.FindAsync([updateAppointment.TestAppointmentId], cancellationToken);
            if(testAppointment is null)
                return false;
            testAppointment.AppointmentDate = updateAppointment.AppointmentDate;
            testAppointment.CreatedByUserId = updateAppointment.CreatedByUserId;
            testAppointment.IsLocked = updateAppointment.IsLocked;
            testAppointment.LocalDrivingLicenseId = updateAppointment.LocalDrivingLicenseId;
            testAppointment.PaidFees = updateAppointment.PaidFees;
            testAppointment.RetakeTestApplicationId = updateAppointment.RetakeTestApplicationId;
            testAppointment.TestTypeId = updateAppointment.TestTypeId;

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<TestAppointment?> FindAppointmentAsync(int appId, CancellationToken cancellationToken)
        {
            var testAppointment = await context.TestAppointments.FindAsync([appId], cancellationToken);
            return testAppointment;
        }

        public async Task<TestAppointment?> GetLastTestAppointmentAsync(int localId, TestTypeEnum testType, CancellationToken cancellationToken)
        {
            var last = await context.TestAppointments.AsNoTracking().OrderByDescending(t => t.TestAppointmentId)
                            .FirstOrDefaultAsync(t => t.LocalDrivingLicenseId == localId && t.TestTypeId == testType, cancellationToken);
            return last;
        }

        public async Task<int> GetTrialsAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken)
        {
            int trials = await context.TestAppointments.AsNoTracking()
                            .CountAsync(t => t.LocalDrivingLicenseId == localId && t.TestTypeId == typeId, cancellationToken);
            return trials;
        }

        public async Task<bool> AppointmentIsLockAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken)
        {
            bool isLock = await context.TestAppointments.AsNoTracking()
                        .OrderByDescending(t => t.TestAppointmentId)
                        .Where(t => t.LocalDrivingLicenseId == localId && t.TestTypeId == typeId)
                        .Select(t => t.IsLocked).FirstOrDefaultAsync(cancellationToken);
            return isLock;
        }

        public async Task<int> GetTestIDAsync(int testAppointmentID, CancellationToken cancellationToken)
        {
            int testId = await context.Tests.AsNoTracking()
                        .Where(t => t.TestAppointmentId == testAppointmentID)
                        .Select(t => t.TestId)
                        .SingleOrDefaultAsync(cancellationToken);
            return testId;
        }
    }
}
