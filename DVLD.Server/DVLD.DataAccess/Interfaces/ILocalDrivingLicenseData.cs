using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface ILocalDrivingLicenseData
{
    Task<int> AddNewLocalAsync(LocalDrivingLicense newLocalLicense, CancellationToken cancellationToken);
    Task<bool> UpdateLocalAsync(LocalDrivingLicense updateLocalLicense, CancellationToken cancellationToken);
    Task<bool> DeleteLocalAsync(int localId, int appId, CancellationToken cancellationToken);
    Task<bool> CheckPersonHasSameClassAsync(int personId, int classId, CancellationToken cancellationToken);
    Task<List<LocalDrivingLicenseApplication>> GetAllLocalLicensesAsync(CancellationToken cancellationToken);
    Task<bool> CancelLicenseAsync(int localLicenseAppID, CancellationToken cancellationToken);
    Task<LocalDrivingLicense?> FindLocalLicenseAsync(int localLicenseID, CancellationToken cancellationToken);
    Task<bool> DoseAttendTestTypeAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken);
    Task<int> TotalTrialsPerTestAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken);
    Task<bool> IsThereAnActiveScheduleTestAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken);
    Task<bool> DosePassTestTypeAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken);
    Task<byte> GetPassedTestCountAsync(int localLicenseID, CancellationToken cancellationToken);
}
