using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface IDetainLicenseService
{
    Task<bool> AddNewDetainLicenseAsync(DetainedLicense newDetain, CancellationToken cancellationToken);
    Task<bool> UpdateDetainLicenseAsync(DetainedLicense updateLicense, CancellationToken cancellationToken);
    Task<DetainedLicense?> FindDetainLicenseAsync(int licenseId, CancellationToken cancellationToken);
    Task<DetainedLicense?> FindDetainLicenseByDetainIdAsync(int detainId, CancellationToken cancellationToken);
    Task<List<DetainedLicenseInfo>> GetDetainedLicensesAsync(CancellationToken cancellationToken);
    Task<bool> ReleaseDetainedLicenseAsync(DetainedLicense releaseLicense, CancellationToken cancellationToken);
    Task<bool> IsDetainedLicenseAsync(int licenseId, CancellationToken cancellationToken);
}
