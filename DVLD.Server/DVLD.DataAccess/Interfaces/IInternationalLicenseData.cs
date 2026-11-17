using DVLD.Shared.Models;
namespace DVLD.DataAccess.Interfaces;

public interface IInternationalLicenseData
{
    Task<int> AddNewInternationalLicenseAsync(InternationalLicense newLicense, CancellationToken cancellationToken);
    Task<InternationalLicense?> FindLicenseAsync(int internationalId, CancellationToken cancellationToken);
    Task<InternationalLicense?> FindLicenseByLocalIdAsync(int LocalLicenseID, CancellationToken cancellationToken);
    Task<List<InternationalLicense>> GetAllLicensesAsync(CancellationToken cancellationToken);
    Task<List<InternationalLicense>> GetInternationalLicenseHistoryAsync(int driverId, CancellationToken cancellationToken);
    Task<int> GetActiveInternationalLicenseIdAsync(int driverId, CancellationToken cancellationToken);
}
