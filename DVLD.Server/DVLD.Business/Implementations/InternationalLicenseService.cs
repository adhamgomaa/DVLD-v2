using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business.Implementations
{
    public sealed class InternationalLicenseService(IInternationalLicenseData internationalLicenseData) : IInternationalLicenseService
    {
        public async Task<bool> AddNewLicenseAsync(InternationalLicense newLicense, CancellationToken cancellationToken)
        {
            newLicense.InternationalID = await internationalLicenseData.AddNewInternationalLicenseAsync(newLicense, cancellationToken);
            return newLicense.InternationalID != -1;
        }

        public async Task<InternationalLicense?> FindLicenseAsync(int internationalID, CancellationToken cancellationToken)
        {
            InternationalLicense? license = await internationalLicenseData.FindLicenseAsync(internationalID, cancellationToken);
            if (license != null)
                return license;
            return null;
        }

        public async Task<InternationalLicense?> FindLicenseByLocalIdAsync(int localId, CancellationToken cancellationToken)
        {
            InternationalLicense? license = await internationalLicenseData.FindLicenseByLocalIdAsync(localId, cancellationToken);
            if (license != null)
                return license;
            return null;
        }

        public async Task<List<InternationalLicense>> GetAllLicensesAsync(CancellationToken cancellationToken)
        {
            return await internationalLicenseData.GetAllLicensesAsync(cancellationToken);
        }

        public async Task<List<InternationalLicense>> GetInternationalLicensesHistoryAsync(int driverId, CancellationToken cancellationToken)
        {
            return await internationalLicenseData.GetInternaionalLicenseHistoryAsync(driverId, cancellationToken);
        }

        public async Task<int> GetActiveInternationalLicenseIdAsync(int driverId, CancellationToken cancellationToken)
        {
            return await internationalLicenseData.GetActiveInternationalLicenseIdAsync(driverId, cancellationToken);
        }
    }
}
