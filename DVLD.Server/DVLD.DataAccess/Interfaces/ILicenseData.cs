using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface ILicenseData
{
    Task<int> AddNewLicenseAsync(License newLicense, CancellationToken cancellationToken);
    Task<bool> UpdateLicenseAsync(License updateLicense, CancellationToken cancellationToken);
    Task<License?> FindLicenseAsync(int licenseId, CancellationToken cancellationToken);
    Task<int> GetLicenseIDAsync(int localId, CancellationToken cancellationToken);
    Task<int> GetLicenseIDAsync(string nationalNo, CancellationToken cancellationToken);
    Task<List<LicenseHistory>> GetLocalLicenseHistoryAsync(int driverId, CancellationToken cancellationToken);
    Task<bool> DeactivateLicenseAsync(int licenseId, CancellationToken cancellationToken);
    Task<int> GetActiveLicenseWithLicenseClassAsync(int personId, int licenseClassId, CancellationToken cancellationToken);
}
