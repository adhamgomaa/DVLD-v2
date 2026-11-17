using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface ILocalDrivingLicenseService
{
    Task<bool> AddNewLocalAsync(LocalDrivingLicense newLocal, CancellationToken cancellationToken);
    Task<bool> UpdateLocalAsync(LocalDrivingLicense updateLicense, CancellationToken cancellationToken);
    Task<bool> CheckPersonHasSameClassAsync(int personId, int classId, CancellationToken cancellationToken);
    Task<byte> GetPassedTestCountAsync(int localId, CancellationToken cancellationToken);
    Task<int> GetTotalTrailsPerTestAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken);
    Task<bool> DoseAttendTestTypeAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken);
    Task<bool> DosePassTestTypeAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken);
    Task<bool> IsThereAnActiveTestAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken);
    Task<List<LocalDrivingLicenseApplication>> GetAllLocalLicensesAsync(CancellationToken cancellationToken);
    Task<bool> CancelLicenseAsync(int localLicenseAppID, CancellationToken cancellationToken);
    Task<LocalDrivingLicense?> FindLocalLicenseAsync(int localLicenseId, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int localId, int appId, CancellationToken cancellationToken);
}
