using DVLD.DataAccess.Data;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.DataAccess.Implementations
{
    public sealed class TestData(AppDbContext context) : ITestData
    {
        public async Task<int> AddNewTestAsync(Test newTest, CancellationToken cancellationToken)
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var appointment = await context.TestAppointments.FindAsync([newTest.TestAppointmentId], cancellationToken);
                if(appointment is null)
                    return -1;
                appointment.IsLocked = true;
                context.Tests.Add(newTest);
                await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return newTest.TestId;
            } catch
            {
                await transaction.RollbackAsync(cancellationToken);
                return -1;
            }
        }

        public async Task<bool> UpdateTestAsync(Test updateTest, CancellationToken cancellationToken)
        {
            var test = await context.Tests.FindAsync([updateTest.TestId], cancellationToken);
            if(test is null)
                return false;
            test.CreatedByUserId = updateTest.CreatedByUserId;
            test.Notes = updateTest.Notes;
            test.TestAppointmentId = updateTest.TestAppointmentId;
            test.TestResult = updateTest.TestResult;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Test?> FindTest(int appointmentId, CancellationToken cancellationToken)
        {
            var test = await context.Tests.AsNoTracking().SingleOrDefaultAsync(t => t.TestAppointmentId == appointmentId, cancellationToken);
            return test;
        }

        public async Task<Test?> GetLastTestAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken)
        {
            var lastTest = await context.Tests.AsNoTracking()
                            .Where(t => t.TestAppointment.LocalDrivingLicenseId == localId &&
                            t.TestAppointment.TestTypeId == typeId)
                            .OrderByDescending(t => t.TestId)
                            .FirstOrDefaultAsync(cancellationToken);
            return lastTest;
        }
    }
}
