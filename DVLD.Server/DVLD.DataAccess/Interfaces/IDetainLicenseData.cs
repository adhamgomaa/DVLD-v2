using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface IDetainLicenseData
{
    Task<int> AddNewDetainAsync(DetainedLicense newDetain, CancellationToken cancellationToken);
    Task<bool> UpdateDetainLicenseAsync(DetainedLicense updateDetain, CancellationToken cancellationToken);
    Task<DetainedLicense?> FindLicenseAsync(int licenseId, CancellationToken cancellationToken);
    Task<DetainedLicense?> FindDetainLicenseByDetainIdAsync(int detainId, CancellationToken cancellationToken);
    Task<List<DetainedLicenseInfo>> GetDetainedLicensesAsync(CancellationToken cancellationToken);
    Task<int> ReleaseDetainedLicenseAsync(DetainedLicense releaseLicense, CancellationToken cancellationToken);
    Task<bool> IsDetainedLicenseAsync(int licenseId, CancellationToken cancellationToken);
}
