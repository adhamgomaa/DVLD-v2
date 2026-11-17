using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;

namespace DVLD.Business.Implementations
{
    public sealed class InternationalLicenseService(IInternationalLicenseData internationalLicenseData) : IInternationalLicenseService
    {
        public async Task<bool> AddNewLicenseAsync(InternationalLicense newLicense, CancellationToken cancellationToken)
        {
            await internationalLicenseData.AddNewInternationalLicenseAsync(newLicense, cancellationToken);
            return newLicense.InternationalLicenseId != -1;
        }

        public Task<InternationalLicense?> FindLicenseAsync(int internationalID, CancellationToken cancellationToken) =>
            internationalLicenseData.FindLicenseAsync(internationalID, cancellationToken);

        public Task<InternationalLicense?> FindLicenseByLocalIdAsync(int localId, CancellationToken cancellationToken) =>
            internationalLicenseData.FindLicenseByLocalIdAsync(localId, cancellationToken);

        public Task<List<InternationalLicense>> GetAllLicensesAsync(CancellationToken cancellationToken) =>
            internationalLicenseData.GetAllLicensesAsync(cancellationToken);

        public Task<List<InternationalLicense>> GetInternationalLicensesHistoryAsync(int driverId, CancellationToken cancellationToken) =>
            internationalLicenseData.GetInternationalLicenseHistoryAsync(driverId, cancellationToken);

        public Task<int> GetActiveInternationalLicenseIdAsync(int driverId, CancellationToken cancellationToken) =>
            internationalLicenseData.GetActiveInternationalLicenseIdAsync(driverId, cancellationToken);
    }
}
