using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface ILocalDrivingLicenseData
{
    Task<int> AddNewLocalAsync(LocalLicense newLocalLicense, CancellationToken cancellationToken);
    Task<bool> UpdateLocalAsync(LocalLicense updateLocalLicense, CancellationToken cancellationToken);
    Task<bool> DeleteLocalAsync(int localId, int appId, CancellationToken cancellationToken);
    Task<bool> CheckPersonHasSameClassAsync(int personId, int classId, CancellationToken cancellationToken);
    Task<List<LocalDrivingApplications>> GetAllLocalLicensesAsync(CancellationToken cancellationToken);
    Task<bool> CancelLicenseAsync(int localLicenseAppID, CancellationToken cancellationToken);
    Task<LocalLicense?> FindLocalLicenseAsync(int localLicenseID, CancellationToken cancellationToken);
    Task<bool> DoseAttendTestTypeAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken);
    Task<byte> TotalTrialsPerTestAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken);
    Task<bool> IsThereAnActiveScheduleTestAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken);
    Task<bool> DosePassTestTypeAsync(int localLicenseAppID, TestTypeEnum testTypeID, CancellationToken cancellationToken);
    Task<byte> GetPassedTestCountAsync(int localLicenseID, CancellationToken cancellationToken);
}
