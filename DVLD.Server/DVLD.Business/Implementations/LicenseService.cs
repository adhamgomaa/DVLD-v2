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

namespace DVLD.Business.Implementations
{
    public sealed class LicenseService(ILicenseData licenseData) : ILicenseService
    {
        public async Task<bool> AddNewLicenseAsync(License newLicense, CancellationToken cancellationToken)
        {
            newLicense.LicenseID = await licenseData.AddNewLicenseAsync(newLicense, cancellationToken);
            return newLicense.LicenseID != -1;
        }

        public async Task<bool> UpdateLicenseAsync(License updateLicense, CancellationToken cancellationToken)
        {
            return await licenseData.UpdateLicenseAsync(updateLicense, cancellationToken);
        }

        public async Task<License?> FindLicenseAsync(int id, CancellationToken cancellationToken)
        {
            License? license = await licenseData.FindLicenseAsync(id, cancellationToken);
            if (license != null)
                return license;
            return null;
        }

        public async Task<int> GetLicenseIDAsync(int LocalId, CancellationToken cancellationToken)
        {
            return await licenseData.GetLicenseIDAsync(LocalId, cancellationToken);
        }

        public async Task<int> GetLicenseIDAsync(string nationalNo, CancellationToken cancellationToken)
        {
            return await licenseData.GetLicenseIDAsync(nationalNo, cancellationToken);
        }

        public async Task<List<LicenseHistory>>  GetLocalLicensesHistoryAsync(int driverId, CancellationToken cancellationToken)
        {
            return await licenseData.GetLocalLicenseHistoryAsync(driverId, cancellationToken);
        }

        public async Task<bool> DeactivateLicenseAsync(int licenseId, CancellationToken cancellationToken)
        {
            return await licenseData.DeactivateLicenseAsync(licenseId, cancellationToken);
        }

        public async Task<int> GetActiveLicenseWithLicenseClassAsync(int personId, int classID, CancellationToken cancellationToken)
        {
            return await licenseData.GetActiveLicenseWithLicenseClassAsync(personId, classID, cancellationToken);
        }
    }
}
