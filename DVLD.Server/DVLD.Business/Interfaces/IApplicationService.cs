using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface IApplicationService
{
    Task<bool> AddNewAppAsync(Application newApp, CancellationToken cancellationToken);
    Task<bool> UpdateAppAsync(Application updateApp, CancellationToken cancellationToken);
    Task<Application?> FindAppAsync(int id, CancellationToken cancellationToken);
    Task<bool> DeleteAppAsync(int id, CancellationToken cancellationToken);
}
