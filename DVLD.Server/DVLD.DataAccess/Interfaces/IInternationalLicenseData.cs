using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface IInternationalLicenseData
{
    Task<int> AddNewInternationalLicenseAsync(InternationalLicense newLicense, CancellationToken cancellationToken);
    Task<InternationalLicense?> FindLicenseAsync(int internationalId, CancellationToken cancellationToken);
    Task<InternationalLicense?> FindLicenseByLocalIdAsync(int LocalLicensID, CancellationToken cancellationToken);
    Task<List<InternationalLicense>> GetAllLicensesAsync(CancellationToken cancellationToken);
    Task<List<InternationalLicense>> GetInternaionalLicenseHistoryAsync(int driverId, CancellationToken cancellationToken);
    Task<int> GetActiveInternationalLicenseIdAsync(int driverId, CancellationToken cancellationToken);
}
