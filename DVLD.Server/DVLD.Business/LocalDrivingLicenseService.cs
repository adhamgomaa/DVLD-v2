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
    public class LocalDrivingLicenseService
    {
        public static async Task<bool> AddNewLocalAsync(LocalLicense newLocal)
        {
            newLocal.LocalId = await LocalDrivingLicenseData.AddNewLocalAsync(newLocal);
            return newLocal.LocalId != -1;
        }

        public static async Task<bool> UpdateLocalAsync(LocalLicense updateLicense)
        {
            return await LocalDrivingLicenseData.UpdateLocalAsync(updateLicense);
        }

        public static async Task<bool> CheckPersonHasSameClassAsync(int personId, int classId)
        {
            return await LocalDrivingLicenseData.CheckPersonHasSameClassAsync(personId, classId);
        }

        public static async Task<byte> GetPassedTestCountAsync(int localId)
        {
            return await LocalDrivingLicenseData.GetPassedTestCountAsync(localId);
        }

        public static async Task<byte> GetTotalTrailsPerTestAsync(int localId, TestTypeEnum testTypeId)
        {
            return await LocalDrivingLicenseData.TotalTrialsPerTestAsync(localId, testTypeId);
        }

        public static async Task<bool> DoseAttendTestTypeAsync(int localId, TestTypeEnum testTypeId)
        {
            return await LocalDrivingLicenseData.DoseAttendTestTypeAsync(localId, testTypeId);
        }
        public static async Task<bool> DosePassTestTypeAsync(int localId, TestTypeEnum testTypeId)
        {
            return await LocalDrivingLicenseData.DosePassTestTypeAsync(localId, testTypeId);
        }
        public static async Task<bool> IsThereAnActiveTestAsync(int localId, TestTypeEnum testTypeId)
        {
            return await LocalDrivingLicenseData.IsThereAnActiveScheduleTestAsync(localId, testTypeId);
        }

        public static async Task<List<LocalDrivingApplications>> GetAllLocalLicensesAsync()
        {
            return await LocalDrivingLicenseData.GetAllLocalLicensesAsync();
        }

        public static async Task<bool> CancelLicenseAsync(int localLicenseAppID)
        {
            return await LocalDrivingLicenseData.CancelLicenseAsync(localLicenseAppID);
        }

        public static async Task<LocalLicense?> FindLocalLicenseAsync(int localLicenseId)
        {
            LocalLicense? local = await LocalDrivingLicenseData.FindLocalLicenseAsync(localLicenseId);
            if (local != null)
                return local;
            return null;
        }

        public static async Task<bool> DeleteAsync(int localId, int appId)
        {
            return await LocalDrivingLicenseData.DeleteLocalAsync(localId, appId);
        }
    }
}
