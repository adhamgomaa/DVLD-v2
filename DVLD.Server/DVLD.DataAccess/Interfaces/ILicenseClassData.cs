using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface ILicenseClassData
{
    Task<LicenseClass?> FindClassesAsync(string className, CancellationToken cancellationToken);
    Task<LicenseClass?> FindClassesAsync(int id, CancellationToken cancellationToken);
    Task<List<LicenseClass>> GetAllClassesAsync(CancellationToken cancellationToken);
}
