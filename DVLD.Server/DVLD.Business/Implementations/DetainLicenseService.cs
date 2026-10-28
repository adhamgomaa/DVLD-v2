using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business.Implementations
{
    public sealed class DetainLicenseService(IDetainLicenseData detainLicenseData) : IDetainLicenseService
    {
        public async Task<bool> AddNewDetainLicenseAsync(DetainLicense newDetain, CancellationToken cancellationToken)
        {
            newDetain.DetainID = await detainLicenseData.AddNewDetainAsync(newDetain, cancellationToken);
            return newDetain.DetainID != -1;
        }

        public async Task<bool> UpdateDetainLicenseAsync(DetainLicense updateLicense, CancellationToken cancellationToken)
        {
            return await detainLicenseData.UpdateDetainLicenseAsync(updateLicense, cancellationToken);
        }

        public async Task<DetainLicense?> FindDetainLicenseAsync(int licenseId, CancellationToken cancellationToken)
        {
            DetainLicense? license = await detainLicenseData.FindLicenseAsync(licenseId, cancellationToken);
            if (license != null)
                return license;
            return null;
        }

        public async Task<List<DetainLicenseInfo>> GetDetainedLicensesAsync(CancellationToken cancellationToken)
        {
            return await detainLicenseData.GetDetainedLicensesAsync(cancellationToken);
        }

        public async Task<bool> ReleaseDetainedLicenseAsync(DetainLicense releaseLicense, CancellationToken cancellationToken)
        {
            releaseLicense.ReleaseAppId = await detainLicenseData.ReleaseDetainedLicenseAsync(releaseLicense, cancellationToken);
            return releaseLicense.ReleaseAppId != -1;
        }

        public async Task<bool> IsDetainedLicenseAsync(int licenseId, CancellationToken cancellationToken)
        {
            return await detainLicenseData.IsDetainedLicenseAsync(licenseId, cancellationToken);
        }
    }
}
