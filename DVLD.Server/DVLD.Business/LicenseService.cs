using DVLD.DataAccess;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class LicenseService
    {
        public static async Task<bool> AddNewLicenseAsync(License newLicense)
        {
            newLicense.LicenseID = await LicenseData.AddNewLicenseAsync(newLicense);
            return newLicense.LicenseID != -1;
        }

        public static async Task<bool> UpdateLicenseAsync(License updateLicense)
        {
            return await LicenseData.UpdateLicenseAsync(updateLicense);
        }

        public static async Task<License?> FindLicenseAsync(int id)
        {
            License? license = await LicenseData.FindLicenseAsync(id);
            if (license != null)
                return license;
            return null;
        }

        public static async Task<int> GetLicenseIDAsync(int LocalId)
        {
            return await LicenseData.GetLicenseIDAsync(LocalId);
        }

        public static async Task<int> GetLicenseIDAsync(string nationalNo)
        {
            return await LicenseData.GetLicenseIDAsync(nationalNo);
        }

        public static async Task<List<LicenseHistory>>  GetLocalLicensesHistoryAsync(int driverId)
        {
            return await LicenseData.GetLocalLicenseHistoryAsync(driverId);
        }

        public static async Task<bool> DeactivateLicenseAsync(int licenseId)
        {
            return await LicenseData.DeactivateLicenseAsync(licenseId);
        }

        public static async Task<int> GetActiveLicenseWithLicenseClassAsync(int personId, int classID)
        {
            return await LicenseData.GetActiveLicenseWithLicenseClassAsync(personId, classID);
        }
    }
}
