using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;

namespace DVLD.Business.Implementations
{
    public sealed class DetainLicenseService(IDetainLicenseData detainLicenseData) : IDetainLicenseService
    {
        public async Task<bool> AddNewDetainLicenseAsync(DetainedLicense newDetain, CancellationToken cancellationToken)
        {
            await detainLicenseData.AddNewDetainAsync(newDetain, cancellationToken);
            return newDetain.DetainId != -1;
        }

        public Task<bool> UpdateDetainLicenseAsync(DetainedLicense updateLicense, CancellationToken cancellationToken) =>
            detainLicenseData.UpdateDetainLicenseAsync(updateLicense, cancellationToken);

        public Task<DetainedLicense?> FindDetainLicenseAsync(int licenseId, CancellationToken cancellationToken) =>
            detainLicenseData.FindLicenseAsync(licenseId, cancellationToken);

        public Task<DetainedLicense?> FindDetainLicenseByDetainIdAsync(int detainId, CancellationToken cancellationToken) =>
            detainLicenseData.FindDetainLicenseByDetainIdAsync(detainId, cancellationToken);

        public Task<List<DetainedLicenseInfo>> GetDetainedLicensesAsync(CancellationToken cancellationToken) =>
            detainLicenseData.GetDetainedLicensesAsync(cancellationToken);

        public async Task<bool> ReleaseDetainedLicenseAsync(DetainedLicense releaseLicense, CancellationToken cancellationToken)
        {
            await detainLicenseData.ReleaseDetainedLicenseAsync(releaseLicense, cancellationToken);
            return releaseLicense.ReleaseApplicationId != -1;
        }

        public Task<bool> IsDetainedLicenseAsync(int licenseId, CancellationToken cancellationToken) =>
            detainLicenseData.IsDetainedLicenseAsync(licenseId, cancellationToken);
    }
}
