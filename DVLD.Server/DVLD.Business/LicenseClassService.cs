using DVLD.DataAccess;
using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class LicenseClassService
    {
        public static async Task<LicenseClass?> FindClassesAsync(string className)
        {
            LicenseClass? license = await LicenseClassData.FindClassesAsync(className);
            if (license != null)
                return license;
            return null;
        }
        public static async Task<LicenseClass?> FindClassesAsync(int id)
        {
            LicenseClass? license = await LicenseClassData.FindClassesAsync(id);
            if (license != null)
                return license;
            return null;
        }
        public static async Task<List<LicenseClass>> GetAllClassesAsync()
        {
            return await LicenseClassData.GetAllClassesAsync();
        }
    }
}
