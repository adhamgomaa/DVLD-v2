using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business.Implementations
{
    public sealed class LocalDrivingLicenseService(ILocalDrivingLicenseData localDrivingLicenseData) : ILocalDrivingLicenseService
    {
        public async Task<bool> AddNewLocalAsync(LocalLicense newLocal, CancellationToken cancellationToken)
        {
            newLocal.LocalId = await localDrivingLicenseData.AddNewLocalAsync(newLocal, cancellationToken);
            return newLocal.LocalId != -1;
        }

        public async Task<bool> UpdateLocalAsync(LocalLicense updateLicense, CancellationToken cancellationToken)
        {
            return await localDrivingLicenseData.UpdateLocalAsync(updateLicense, cancellationToken);
        }

        public async Task<bool> CheckPersonHasSameClassAsync(int personId, int classId, CancellationToken cancellationToken)
        {
            return await localDrivingLicenseData.CheckPersonHasSameClassAsync(personId, classId, cancellationToken);
        }

        public async Task<byte> GetPassedTestCountAsync(int localId, CancellationToken cancellationToken)
        {
            return await localDrivingLicenseData.GetPassedTestCountAsync(localId, cancellationToken);
        }

        public async Task<byte> GetTotalTrailsPerTestAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            return await localDrivingLicenseData.TotalTrialsPerTestAsync(localId, testTypeId, cancellationToken);
        }

        public async Task<bool> DoseAttendTestTypeAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            return await localDrivingLicenseData.DoseAttendTestTypeAsync(localId, testTypeId, cancellationToken);
        }
        public async Task<bool> DosePassTestTypeAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            return await localDrivingLicenseData.DosePassTestTypeAsync(localId, testTypeId, cancellationToken);
        }
        public async Task<bool> IsThereAnActiveTestAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            return await localDrivingLicenseData.IsThereAnActiveScheduleTestAsync(localId, testTypeId, cancellationToken);
        }

        public async Task<List<LocalDrivingApplications>> GetAllLocalLicensesAsync(CancellationToken cancellationToken)
        {
            return await localDrivingLicenseData.GetAllLocalLicensesAsync(cancellationToken);
        }

        public async Task<bool> CancelLicenseAsync(int localLicenseAppID, CancellationToken cancellationToken)
        {
            return await localDrivingLicenseData.CancelLicenseAsync(localLicenseAppID, cancellationToken);
        }

        public async Task<LocalLicense?> FindLocalLicenseAsync(int localLicenseId, CancellationToken cancellationToken)
        {
            LocalLicense? local = await localDrivingLicenseData.FindLocalLicenseAsync(localLicenseId, cancellationToken);
            if (local != null)
                return local;
            return null;
        }

        public async Task<bool> DeleteAsync(int localId, int appId, CancellationToken cancellationToken)
        {
            return await localDrivingLicenseData.DeleteLocalAsync(localId, appId, cancellationToken);
        }
    }
}
