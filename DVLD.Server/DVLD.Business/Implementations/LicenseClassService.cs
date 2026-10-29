using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business.Implementations
{
    public sealed class LicenseClassService(ILicenseClassData licenseClassData) : ILicenseClassService
    {
        public async Task<LicenseClass?> FindClassesAsync(string className, CancellationToken cancellationToken)
        {
            LicenseClass? license = await licenseClassData.FindClassesAsync(className, cancellationToken);
            if (license != null)
                return license;
            return null;
        }
        public async Task<LicenseClass?> FindClassesAsync(int id, CancellationToken cancellationToken)
        {
            LicenseClass? license = await licenseClassData.FindClassesAsync(id, cancellationToken);
            if (license != null)
                return license;
            return null;
        }
        public async Task<List<LicenseClass>> GetAllClassesAsync(CancellationToken cancellationToken)
        {
            return await licenseClassData.GetAllClassesAsync(cancellationToken);
        }
    }
}
