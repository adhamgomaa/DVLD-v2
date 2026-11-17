using DVLD.DataAccess.Data;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace DVLD.DataAccess.Implementations
{
    public sealed class LicenseClassData(AppDbContext context) : ILicenseClassData
    {
        public async Task<LicenseClass?> FindClassesAsync(string className, CancellationToken cancellationToken)
        {
            var license = await context.LicenseClasses.AsNoTracking().SingleOrDefaultAsync(c => c.ClassName == className, cancellationToken);
            return license;
        }
        public async Task<LicenseClass?> FindClassesAsync(int id, CancellationToken cancellationToken)
        {
            var license = await context.LicenseClasses.FindAsync([id], cancellationToken);
            return license;
        }

        public async Task<List<LicenseClass>> GetAllClassesAsync(CancellationToken cancellationToken)
        {
            var licenses = await context.LicenseClasses.AsNoTracking().ToListAsync(cancellationToken);
            return licenses;
        }
    }
}
