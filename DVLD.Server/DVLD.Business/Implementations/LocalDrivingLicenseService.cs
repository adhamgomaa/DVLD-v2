using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.Business.Implementations
{
    public sealed class LocalDrivingLicenseService(ILocalDrivingLicenseData localDrivingLicenseData) : ILocalDrivingLicenseService
    {
        public async Task<bool> AddNewLocalAsync(LocalDrivingLicense newLocal, CancellationToken cancellationToken)
        {
            await localDrivingLicenseData.AddNewLocalAsync(newLocal, cancellationToken);
            return newLocal.LocalDrivingLicenseApplicationId != -1;
        }

        public Task<bool> UpdateLocalAsync(LocalDrivingLicense updateLicense, CancellationToken cancellationToken) =>
            localDrivingLicenseData.UpdateLocalAsync(updateLicense, cancellationToken);

        public Task<bool> CheckPersonHasSameClassAsync(int personId, int classId, CancellationToken cancellationToken) =>
            localDrivingLicenseData.CheckPersonHasSameClassAsync(personId, classId, cancellationToken);

        public Task<byte> GetPassedTestCountAsync(int localId, CancellationToken cancellationToken) =>
            localDrivingLicenseData.GetPassedTestCountAsync(localId, cancellationToken);

        public Task<int> GetTotalTrailsPerTestAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken) =>
            localDrivingLicenseData.TotalTrialsPerTestAsync(localId, testTypeId, cancellationToken);

        public Task<bool> DoseAttendTestTypeAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken) =>
            localDrivingLicenseData.DoseAttendTestTypeAsync(localId, testTypeId, cancellationToken);
        public Task<bool> DosePassTestTypeAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken) =>
            localDrivingLicenseData.DosePassTestTypeAsync(localId, testTypeId, cancellationToken);
        public Task<bool> IsThereAnActiveTestAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken) =>
            localDrivingLicenseData.IsThereAnActiveScheduleTestAsync(localId, testTypeId, cancellationToken);

        public Task<List<LocalDrivingLicenseApplication>> GetAllLocalLicensesAsync(CancellationToken cancellationToken) =>
            localDrivingLicenseData.GetAllLocalLicensesAsync(cancellationToken);

        public Task<bool> CancelLicenseAsync(int localLicenseAppID, CancellationToken cancellationToken) =>
            localDrivingLicenseData.CancelLicenseAsync(localLicenseAppID, cancellationToken);

        public Task<LocalDrivingLicense?> FindLocalLicenseAsync(int localLicenseId, CancellationToken cancellationToken) =>
            localDrivingLicenseData.FindLocalLicenseAsync(localLicenseId, cancellationToken);

        public Task<bool> DeleteAsync(int localId, int appId, CancellationToken cancellationToken) =>
            localDrivingLicenseData.DeleteLocalAsync(localId, appId, cancellationToken);
    }
}
