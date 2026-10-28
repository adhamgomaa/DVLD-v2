using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface ILocalDrivingLicenseService
{
    Task<bool> AddNewLocalAsync(LocalLicense newLocal, CancellationToken cancellationToken);
    Task<bool> UpdateLocalAsync(LocalLicense updateLicense, CancellationToken cancellationToken);
    Task<bool> CheckPersonHasSameClassAsync(int personId, int classId, CancellationToken cancellationToken);
    Task<byte> GetPassedTestCountAsync(int localId, CancellationToken cancellationToken);
    Task<byte> GetTotalTrailsPerTestAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken);
    Task<bool> DoseAttendTestTypeAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken);
    Task<bool> DosePassTestTypeAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken);
    Task<bool> IsThereAnActiveTestAsync(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken);
    Task<List<LocalDrivingApplications>> GetAllLocalLicensesAsync(CancellationToken cancellationToken);
    Task<bool> CancelLicenseAsync(int localLicenseAppID, CancellationToken cancellationToken);
    Task<LocalLicense?> FindLocalLicenseAsync(int localLicenseId, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int localId, int appId, CancellationToken cancellationToken);
}
