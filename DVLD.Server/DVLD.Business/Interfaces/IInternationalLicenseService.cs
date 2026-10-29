using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface IInternationalLicenseService
{
    Task<bool> AddNewLicenseAsync(InternationalLicense newLicense, CancellationToken cancellationToken);
    Task<InternationalLicense?> FindLicenseAsync(int internationalID, CancellationToken cancellationToken);
    Task<InternationalLicense?> FindLicenseByLocalIdAsync(int localId, CancellationToken cancellationToken);
    Task<List<InternationalLicense>> GetAllLicensesAsync(CancellationToken cancellationToken);
    Task<List<InternationalLicense>> GetInternationalLicensesHistoryAsync(int driverId, CancellationToken cancellationToken);
    Task<int> GetActiveInternationalLicenseIdAsync(int driverId, CancellationToken cancellationToken);
}
