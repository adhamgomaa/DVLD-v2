using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;

namespace DVLD.Business.Implementations
{
    public sealed class LicenseClassService(ILicenseClassData licenseClassData) : ILicenseClassService
    {
        public Task<LicenseClass?> FindClassesAsync(string className, CancellationToken cancellationToken) =>
            licenseClassData.FindClassesAsync(className, cancellationToken);
        public Task<LicenseClass?> FindClassesAsync(int id, CancellationToken cancellationToken) =>
            licenseClassData.FindClassesAsync(id, cancellationToken);
        public Task<List<LicenseClass>> GetAllClassesAsync(CancellationToken cancellationToken) =>
            licenseClassData.GetAllClassesAsync(cancellationToken);
    }
}
