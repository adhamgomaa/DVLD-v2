using DVLD.DataAccess;
using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class InternationalLicenseService
    {
        public static async Task<bool> AddNewLicenseAsync(InternationalLicense newLicense)
        {
            newLicense.InternationalID = await InternationalLicenseData.AddNewInternationalLicenseAsync(newLicense);
            return newLicense.InternationalID != -1;
        }

        public static async Task<InternationalLicense?> FindLicenseAsync(int internationalID)
        {
            InternationalLicense? license = await InternationalLicenseData.FindLicenseAsync(internationalID);
            if (license != null)
                return license;
            return null;
        }

        public static async Task<InternationalLicense?> FindLicenseByLocalIdAsync(int localId)
        {
            InternationalLicense? license = await InternationalLicenseData.FindLicenseByLocalIdAsync(localId);
            if (license != null)
                return license;
            return null;
        }

        public static async Task<List<InternationalLicense>> GetAllLicensesAsync()
        {
            return await InternationalLicenseData.GetAllLicensesAsync();
        }

        public static async Task<List<InternationalLicense>> GetInternationalLicensesHistoryAsync(int driverId)
        {
            return await InternationalLicenseData.GetInternaionalLicenseHistoryAsync(driverId);
        }

        public static async Task<int> GetActiveInternationalLicenseIdAsync(int driverId)
        {
            return await InternationalLicenseData.GetActiveInternationalLicenseIdAsync(driverId);
        }
    }
}
