using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface IDetainLicenseData
{
    Task<int> AddNewDetainAsync(DetainLicense newDetain, CancellationToken cancellationToken);
    Task<bool> UpdateDetainLicenseAsync(DetainLicense updateDetain, CancellationToken cancellationToken);
    Task<DetainLicense?> FindLicenseAsync(int licenseId, CancellationToken cancellationToken);
    Task<List<DetainLicenseInfo>> GetDetainedLicensesAsync(CancellationToken cancellationToken);
    Task<int> ReleaseDetainedLicenseAsync(DetainLicense releaseLicense, CancellationToken cancellationToken);
    Task<bool> IsDetainedLicenseAsync(int licenseId, CancellationToken cancellationToken);
}
