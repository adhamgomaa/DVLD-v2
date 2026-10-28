using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface IDetainLicenseService
{
    Task<bool> AddNewDetainLicenseAsync(DetainLicense newDetain, CancellationToken cancellationToken);
    Task<bool> UpdateDetainLicenseAsync(DetainLicense updateLicense, CancellationToken cancellationToken);
    Task<DetainLicense?> FindDetainLicenseAsync(int licenseId, CancellationToken cancellationToken);
    Task<List<DetainLicenseInfo>> GetDetainedLicensesAsync(CancellationToken cancellationToken);
    Task<bool> ReleaseDetainedLicenseAsync(DetainLicense releaseLicense, CancellationToken cancellationToken);
    Task<bool> IsDetainedLicenseAsync(int licenseId, CancellationToken cancellationToken);
}
