using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface IApplicationData
{
    Task<int> AddNewAppAsync(Application newApplication, CancellationToken cancellationToken);
    Task<bool> UpdateAppAsync(Application UpdateApplication, CancellationToken cancellationToken);
    Task<bool> DeleteAppAsync(int appId, CancellationToken cancellationToken);
    Task<Application?> FindAppAsync(int id, CancellationToken cancellationToken);
}
