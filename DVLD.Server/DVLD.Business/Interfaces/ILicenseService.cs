using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface ILicenseService
{
    Task<bool> AddNewLicenseAsync(License newLicense, CancellationToken cancellationToken);
    Task<bool> UpdateLicenseAsync(License updateLicense, CancellationToken cancellationToken);
    Task<License?> FindLicenseAsync(int id, CancellationToken cancellationToken);
    Task<int> GetLicenseIDAsync(int LocalId, CancellationToken cancellationToken);
    Task<int> GetLicenseIDAsync(string nationalNo, CancellationToken cancellationToken);
    Task<List<LicenseHistory>> GetLocalLicensesHistoryAsync(int driverId, CancellationToken cancellationToken);
    Task<bool> DeactivateLicenseAsync(int licenseId, CancellationToken cancellationToken);
    Task<int> GetActiveLicenseWithLicenseClassAsync(int personId, int classID, CancellationToken cancellationToken);
}
