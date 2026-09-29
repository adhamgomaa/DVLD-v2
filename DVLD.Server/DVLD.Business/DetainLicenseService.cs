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
    public class DetainLicenseService
    {
        public static async Task<bool> AddNewDetainLicenseAsync(DetainLicense newDetain)
        {
            newDetain.DetainID = await DetainLicenseData.AddNewDetainAsync(newDetain);
            return newDetain.DetainID != -1;
        }

        public static async Task<bool> UpdateDetainLicenseAsync(DetainLicense updateLicense)
        {
            return await DetainLicenseData.UpdateDetainLicenseAsync(updateLicense);
        }

        public static async Task<DetainLicense?> FindDetainLicenseAsync(int licenseId)
        {
            DetainLicense? license = await DetainLicenseData.FindLicenseAsync(licenseId);
            if (license != null)
                return license;
            return null;
        }

        public static async Task<List<DetainLicenseInfo>> GetDetainedLicensesAsync()
        {
            return await DetainLicenseData.GetDetainedLicensesAsync();
        }

        public static async Task<bool> ReleaseDetainedLicenseAsync(DetainLicense releaseLicense)
        {
            releaseLicense.ReleaseAppId = await DetainLicenseData.ReleaseDetainedLicenseAsync(releaseLicense);
            return releaseLicense.ReleaseAppId != -1;
        }

        public static async Task<bool> IsDetainedLicenseAsync(int licenseId)
        {
            return await DetainLicenseData.IsDetainedLicenseAsync(licenseId);
        }
    }
}
