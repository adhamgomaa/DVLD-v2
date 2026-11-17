using DVLD.DataAccess.Data;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DVLD.DataAccess.Implementations
{
    public sealed class DetainLicenseData(AppDbContext context) : IDetainLicenseData
    {
        public async Task<int> AddNewDetainAsync(DetainedLicense newDetain, CancellationToken cancellationToken)
        {
            context.DetainedLicenses.Add(newDetain);
            await context.SaveChangesAsync(cancellationToken);
            return newDetain.DetainId;
        }

        public async Task<bool> UpdateDetainLicenseAsync(DetainedLicense updateDetain, CancellationToken cancellationToken)
        {
            var detain = await context.DetainedLicenses.FindAsync([updateDetain.DetainId], cancellationToken);
            if(detain is null)
                return false;
            detain.CreatedByUserId = updateDetain.CreatedByUserId;
            detain.DetainDate = updateDetain.DetainDate;
            detain.DetainFees = updateDetain.DetainFees;
            detain.IsReleased = updateDetain.IsReleased;
            detain.LicenseId = updateDetain.LicenseId;
            detain.ReleaseApplicationId = updateDetain.ReleaseApplicationId;
            detain.ReleaseDate = updateDetain.ReleaseDate;
            detain.ReleasedByUserId = updateDetain.ReleasedByUserId;
            
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<DetainedLicense?> FindLicenseAsync(int licenseId, CancellationToken cancellationToken)
        {
            var detain = await context.DetainedLicenses.AsNoTracking()
                            .OrderByDescending(d => d.DetainId)
                            .FirstOrDefaultAsync(d => d.LicenseId == licenseId, cancellationToken);
            return detain;
        }

        public async Task<DetainedLicense?> FindDetainLicenseByDetainIdAsync(int detainId, CancellationToken cancellationToken)
        {
            var detain = await context.DetainedLicenses.FindAsync([detainId], cancellationToken);
            return detain;
        }

        public async Task<List<DetainedLicenseInfo>> GetDetainedLicensesAsync(CancellationToken cancellationToken)
        {
            var detains = await context.DetainedLicenses.AsNoTracking()
                                .Select(d => new DetainedLicenseInfo
                                {
                                    DetainId = d.DetainId,
                                    LicenseId = d.LicenseId,
                                    DetainDate = d.DetainDate,
                                    IsReleased = d.IsReleased,
                                    DetainFees = d.DetainFees,
                                    ReleaseDate = d.ReleaseDate,
                                    NationalNo = d.License.Driver.Person.NationalNo,
                                    FullName = d.License.Driver.Person.FirstName + " " + d.License.Driver.Person.SecondName + " " + d.License.Driver.Person.ThirdName + " " + d.License.Driver.Person.LastName,
                                    ReleaseApplicationId = d.ReleaseApplicationId
                                }).ToListAsync(cancellationToken);
            return detains;
        }

        public async Task<int> ReleaseDetainedLicenseAsync(DetainedLicense releaseLicense, CancellationToken cancellationToken)
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var detain = await context.DetainedLicenses.FindAsync([releaseLicense.DetainId], cancellationToken);
                if(detain is null)
                    return -1;

                detain.ReleaseApplication = new Application
                {
                    ApplicantPersonId = releaseLicense.ReleaseApplication!.ApplicantPersonId,
                    ApplicationTypeId = releaseLicense.ReleaseApplication.ApplicationTypeId,
                    ApplicationStatus = releaseLicense.ReleaseApplication.ApplicationStatus,
                    LastStatusDate = releaseLicense.ReleaseApplication.LastStatusDate,
                    PaidFees = releaseLicense.ReleaseApplication.PaidFees,
                    CreatedByUserId = (int)releaseLicense.ReleasedByUserId!,
                };

                detain.IsReleased = releaseLicense.IsReleased;
                detain.ReleaseDate = releaseLicense.ReleaseDate;
                detain.ReleasedByUserId = releaseLicense.ReleasedByUserId;
                await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                releaseLicense.ReleaseApplicationId = (int)detain.ReleaseApplicationId!;
                return (int)detain.ReleaseApplicationId!;
            } catch
            {
                await transaction.RollbackAsync(cancellationToken);
                return -1;
            }
        }

        public async Task<bool> IsDetainedLicenseAsync(int licenseId, CancellationToken cancellationToken)
        {
            bool isDetained = await context.DetainedLicenses.AsNoTracking()
                                    .AnyAsync(d => d.LicenseId == licenseId && d.IsReleased == false, cancellationToken);
            return isDetained;
        }
    }
}
