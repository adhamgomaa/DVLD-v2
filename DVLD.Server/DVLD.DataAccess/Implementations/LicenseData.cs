using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;
using System.Data;
using DVLD.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.DataAccess.Implementations
{
    public sealed class LicenseData(AppDbContext context) : ILicenseData
    {
        public async Task<int> AddNewLicenseAsync(License newLicense, CancellationToken cancellationToken)
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                context.Licenses.Add(newLicense);
                if(newLicense.IssueReason == IssueReasonEnum.FirstTime)
                {
                    var app = await context.Applications.FindAsync([newLicense.ApplicationId], cancellationToken);
                    if(app is null)
                        return -1;
                    app.ApplicationStatus = AppStatusEnum.Completed;
                    app.LastStatusDate = DateTime.Now;
                }

                await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return newLicense.LicenseId;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                return -1;
            }
        }

        public async Task<bool> UpdateLicenseAsync(License updateLicense, CancellationToken cancellationToken)
        {
            var license = await context.Licenses.FindAsync([updateLicense.LicenseId], cancellationToken);
            if(license is null)
                return false;
            license.ApplicationId = updateLicense.ApplicationId;
            license.CreatedByUserId = updateLicense.CreatedByUserId;
            license.DriverId = updateLicense.DriverId;
            license.ExpirationDate = updateLicense.ExpirationDate;
            license.IsActive = updateLicense.IsActive;
            license.IssueDate = updateLicense.IssueDate;
            license.IssueReason = updateLicense.IssueReason;
            license.LicenseClassId = updateLicense.LicenseClassId;
            license.PaidFees = updateLicense.PaidFees;
            license.Notes = updateLicense.Notes;

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<License?> FindLicenseAsync(int licenseId, CancellationToken cancellationToken)
        {
            var license = await context.Licenses.FindAsync([licenseId], cancellationToken);
            return license;
        }

        public async Task<int> GetLicenseIDAsync(int localId, CancellationToken cancellationToken)
        {
            int licenseId = await context.Licenses.AsNoTracking()
                .Join(
                context.LocalDrivingLicenses,
                license => license.ApplicationId,
                local => local.ApplicationId,
                (license, local) => new
                {
                    license.LicenseId,
                    local.LocalDrivingLicenseApplicationId
                }
            ).Where(l => l.LocalDrivingLicenseApplicationId == localId).Select(l => l.LicenseId).SingleOrDefaultAsync(cancellationToken);
            return licenseId;   
        }

        public async Task<int> GetLicenseIDAsync(string nationalNo, CancellationToken cancellationToken)
        {
            int licenseId = await context.Licenses.AsNoTracking()
                                .Where(l => l.Driver.Person.NationalNo == nationalNo)
                                .Select(l => l.LicenseId).SingleOrDefaultAsync(cancellationToken);
            return licenseId;
        }

        public async Task<List<LicenseHistory>> GetLicensesByNationalNoAsync(string nationalNo, CancellationToken cancellationToken)
        {
            var license = await context.Licenses.AsNoTracking()
                            .Where(l => l.Driver.Person.NationalNo == nationalNo)
                            .Select(l => new LicenseHistory
                            {
                                LicenseID = l.LicenseId,
                                AppID = l.ApplicationId,
                                ClassName = l.LicenseClass.ClassName,
                                IssueDate = l.IssueDate,
                                ExpirationDate = l.ExpirationDate,
                                IsActive = l.IsActive
                            }).ToListAsync(cancellationToken);
            return license;
        }

        public async Task<List<LicenseHistory>> GetLocalLicenseHistoryAsync(int driverId, CancellationToken cancellationToken)
        {
            var license = await context.Licenses.AsNoTracking()
                            .Where(l => l.DriverId == driverId)
                            .Select(l => new LicenseHistory
                            {
                                LicenseID = l.LicenseId,
                                AppID = l.ApplicationId,
                                ClassName = l.LicenseClass.ClassName,
                                IssueDate = l.IssueDate,
                                ExpirationDate = l.ExpirationDate,
                                IsActive = l.IsActive
                            }).ToListAsync(cancellationToken);
            return license;
        }

        public async Task<bool> DeactivateLicenseAsync(int licenseId, CancellationToken cancellationToken)
        {
            var license = await context.Licenses.FindAsync([licenseId], cancellationToken);
            if(license is null)
                return false;
            license.IsActive = false;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<int> GetActiveLicenseWithLicenseClassAsync(int personId, int licenseClassId, CancellationToken cancellationToken)
        {
            int licenseId = await context.Licenses.AsNoTracking()
                            .Where(l => l.LicenseClassId == licenseClassId && l.IsActive && l.Driver.PersonId == personId)
                            .Select(l => l.LicenseId).SingleOrDefaultAsync(cancellationToken);
            return licenseId;
        }
    }
}
