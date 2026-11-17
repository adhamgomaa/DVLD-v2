using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.Business.Implementations
{
    public sealed class LicenseService(ILicenseData licenseData) : ILicenseService
    {
        public async Task<bool> AddNewLicenseAsync(License newLicense, CancellationToken cancellationToken)
        {
            await licenseData.AddNewLicenseAsync(newLicense, cancellationToken);
            return newLicense.LicenseId != -1;
        }

        public Task<bool> UpdateLicenseAsync(License updateLicense, CancellationToken cancellationToken) =>
            licenseData.UpdateLicenseAsync(updateLicense, cancellationToken);

        public Task<License?> FindLicenseAsync(int id, CancellationToken cancellationToken) =>
            licenseData.FindLicenseAsync(id, cancellationToken);

        public Task<int> GetLicenseIDAsync(int LocalId, CancellationToken cancellationToken) =>
            licenseData.GetLicenseIDAsync(LocalId, cancellationToken);

        public Task<int> GetLicenseIDAsync(string nationalNo, CancellationToken cancellationToken) =>
            licenseData.GetLicenseIDAsync(nationalNo, cancellationToken);

        public Task<List<LicenseHistory>> GetLicensesByNationalNoAsync(string nationalNo, CancellationToken cancellationToken) =>
            licenseData.GetLicensesByNationalNoAsync(nationalNo, cancellationToken);

        public Task<List<LicenseHistory>>  GetLocalLicensesHistoryAsync(int driverId, CancellationToken cancellationToken) =>
            licenseData.GetLocalLicenseHistoryAsync(driverId, cancellationToken);

        public Task<bool> DeactivateLicenseAsync(int licenseId, CancellationToken cancellationToken) =>
            licenseData.DeactivateLicenseAsync(licenseId, cancellationToken);

        public Task<int> GetActiveLicenseWithLicenseClassAsync(int personId, int classID, CancellationToken cancellationToken) =>
            licenseData.GetActiveLicenseWithLicenseClassAsync(personId, classID, cancellationToken);
    }
}
