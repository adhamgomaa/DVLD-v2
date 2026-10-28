using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface IDriverService
{
    Task<bool> AddNewDriverAsync(Driver newDriver, CancellationToken cancellationToken);
    Task<List<DriverInfo>> ListDriversAsync(CancellationToken cancellationToken);
    Task<bool> IsPersonDriverAsync(int personId, CancellationToken cancellationToken);
    Task<Driver?> FindDriverAsync(int personId, CancellationToken cancellationToken);
    Task<Driver?> FindDriverWithDriverIDAsync(int driverId, CancellationToken cancellationToken);
}
