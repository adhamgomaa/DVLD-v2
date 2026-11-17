using DVLD.DataAccess.Data;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess.Implementations
{
    public sealed class InternationalLicenseData(AppDbContext context) : IInternationalLicenseData
    {
        public async Task<int> AddNewInternationalLicenseAsync(InternationalLicense newLicense, CancellationToken cancellationToken)
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var license = await context.InternationalLicenses.Where(l => l.DriverId == newLicense.DriverId)
                                    .ExecuteUpdateAsync(setter => setter.SetProperty(s => s.IsActive, false), cancellationToken);
                context.InternationalLicenses.Add(newLicense);
                await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return newLicense.InternationalLicenseId;
            } catch
            {
                await transaction.RollbackAsync(cancellationToken);
                return -1;
            }
        }

        public async Task<InternationalLicense?> FindLicenseAsync(int internationalId, CancellationToken cancellationToken)
        {
            var license = await context.InternationalLicenses.FindAsync([internationalId], cancellationToken);
            return license;
        }

        public async Task<InternationalLicense?> FindLicenseByLocalIdAsync(int LocalLicenseID, CancellationToken cancellationToken)
        {
            var license = await context.InternationalLicenses.AsNoTracking()
                                .FirstOrDefaultAsync(l => l.IssuedUsingLocalLicenseId == LocalLicenseID && l.IsActive, cancellationToken);
            return license;
        }

        public async Task<List<InternationalLicense>> GetAllLicensesAsync(CancellationToken cancellationToken)
        {
            var licenses = await context.InternationalLicenses.AsNoTracking().ToListAsync(cancellationToken);
            return licenses;
        }

        public async Task<List<InternationalLicense>> GetInternationalLicenseHistoryAsync(int driverId, CancellationToken cancellationToken)
        {
            var licenses = await context.InternationalLicenses.AsNoTracking().Where(l => l.DriverId == driverId).ToListAsync(cancellationToken);
            return licenses;
        }

        public async Task<int> GetActiveInternationalLicenseIdAsync(int driverId, CancellationToken cancellationToken)
        {
            int internationalId = await context.InternationalLicenses.AsNoTracking()
                                        .Where(l => l.DriverId == driverId && l.IsActive)
                                        .Select(l => l.InternationalLicenseId).FirstOrDefaultAsync(cancellationToken);
            return internationalId;
        }
    }
}
