using DVLD.DataAccess.Data;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.DataAccess.Implementations
{
    public sealed class LocalDrivingLicenseData(AppDbContext context) : ILocalDrivingLicenseData
    {
        public async Task<int> AddNewLocalAsync(LocalDrivingLicense newLocalLicense, CancellationToken cancellationToken)
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                context.LocalDrivingLicenses.Add(newLocalLicense);
                await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return newLocalLicense.LocalDrivingLicenseApplicationId;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                return -1;
            }
        }

        public async Task<bool> UpdateLocalAsync(LocalDrivingLicense updateLocalLicense, CancellationToken cancellationToken)
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var local = await context.LocalDrivingLicenses
                                .Include(license => license.Application)
                                .SingleOrDefaultAsync(
                                    license => license.LocalDrivingLicenseApplicationId == updateLocalLicense.LocalDrivingLicenseApplicationId,
                                    cancellationToken);
                if (local is null)
                    return false;

                local.Application.ApplicantPersonId = updateLocalLicense.Application.ApplicantPersonId;
                local.Application.ApplicationTypeId = updateLocalLicense.Application.ApplicationTypeId;
                local.Application.ApplicationStatus = updateLocalLicense.Application.ApplicationStatus;
                local.Application.LastStatusDate = updateLocalLicense.Application.LastStatusDate;
                local.Application.PaidFees = updateLocalLicense.Application.PaidFees;
                local.Application.CreatedByUserId = updateLocalLicense.Application.CreatedByUserId;
                local.LicenseClassId = updateLocalLicense.LicenseClassId;

                int affectedRows = await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return affectedRows > 0;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                return false;
            }
        }

        public async Task<bool> DeleteLocalAsync(int localId, int appId, CancellationToken cancellationToken)
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var local = await context.LocalDrivingLicenses.FindAsync([localId], cancellationToken);
                var app = await context.Applications.FindAsync([appId], cancellationToken);
                if (local is null || app is null)
                    return false;
                context.LocalDrivingLicenses.Remove(local);
                context.Applications.Remove(app);

                int affectedRows = await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return affectedRows > 0;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                return false;
            }
        }

        public async Task<bool> CheckPersonHasSameClassAsync(int personId, int classId, CancellationToken cancellationToken)
        {
            bool isTheSame = await context.LocalDrivingLicenses.AsNoTracking()
                            .AnyAsync(l => l.LicenseClassId == classId && l.Application.ApplicantPersonId == personId
                            && (l.Application.ApplicationStatus == AppStatusEnum.New || l.Application.ApplicationStatus == AppStatusEnum.Completed),
                            cancellationToken);
            return isTheSame;                
        }

        public async Task<List<LocalDrivingLicenseApplication>> GetAllLocalLicensesAsync(CancellationToken cancellationToken)
        {
            var locals = await context.LocalDrivingLicenseApplications.AsNoTracking()
                            .OrderByDescending(l => l.LDLAppId)
                            .ToListAsync(cancellationToken);
            return locals;
        }

        public async Task<bool> CancelLicenseAsync(int localLicenseAppID, CancellationToken cancellationToken)
        {
            var local = await context.LocalDrivingLicenses
                                        .Include(license => license.Application)
                                        .SingleOrDefaultAsync(
                                            license => license.LocalDrivingLicenseApplicationId == localLicenseAppID,
                                            cancellationToken); 
            if (local is null)
                return false;
            local.Application.ApplicationStatus = AppStatusEnum.Cancelled;
            local.Application.LastStatusDate = DateTime.Now;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<LocalDrivingLicense?> FindLocalLicenseAsync(int localLicenseID, CancellationToken cancellationToken)
        {
            var local = await context.LocalDrivingLicenses
                            .Include(license => license.Application)
                            .SingleOrDefaultAsync(
                                license => license.LocalDrivingLicenseApplicationId == localLicenseID,
                                cancellationToken);
            return local;
        }

        public async Task<bool> DoseAttendTestTypeAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken)
        {
            bool isAttend = await context.Tests.AsNoTracking()
                        .Where(t => t.TestAppointment.LocalDrivingLicense.LocalDrivingLicenseApplicationId == localLicenseAppID &&
                        t.TestAppointment.TestTypeId == testTypeID)
                        .AnyAsync(cancellationToken);
            return isAttend;
        }

        public async Task<int> TotalTrialsPerTestAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken)
        {
            int total = await context.Tests.AsNoTracking()
                        .Where(t => t.TestAppointment.LocalDrivingLicense.LocalDrivingLicenseApplicationId == localLicenseAppID &&
                        t.TestAppointment.TestTypeId == testTypeID)
                        .CountAsync(cancellationToken);
            return total;
        }

        public async Task<bool> IsThereAnActiveScheduleTestAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken)
        {
            bool isFound = await context.TestAppointments
                        .Where(t => t.LocalDrivingLicense.LocalDrivingLicenseApplicationId == localLicenseAppID &&
                        t.TestTypeId == testTypeID && !t.IsLocked)
                        .AnyAsync(cancellationToken);
            return isFound;
        }

        public async Task<bool> DosePassTestTypeAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken)
        {
            bool isPass = await context.Tests
                        .Where(t => t.TestAppointment.LocalDrivingLicense.LocalDrivingLicenseApplicationId == localLicenseAppID &&
                        t.TestAppointment.TestTypeId == testTypeID)
                        .OrderByDescending(t => t.TestAppointmentId)
                        .Select(t => t.TestResult)
                        .FirstOrDefaultAsync(cancellationToken);
            return isPass;
        }

        public async Task<byte> GetPassedTestCountAsync(int localLicenseID, CancellationToken cancellationToken)
        {
            int total = await context.Tests
                        .Where(t => t.TestAppointment.LocalDrivingLicenseId == localLicenseID && t.TestResult)
                        .CountAsync(cancellationToken);
            return (byte)total;
        }
    }
}
