using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface IDriverData
{
    Task<int> AddNewDriverAsync(Driver newDriver, CancellationToken cancellationToken);
    Task<List<DriverInfo>> ListDriversAsync(CancellationToken cancellationToken);
    Task<bool> IsPersonDriverAsync(int personId, CancellationToken cancellationToken);
    Task<Driver?> FindDriverByPersonIdAsync(int personId, CancellationToken cancellationToken);
    Task<Driver?> FindDriverAsync(int driverId, CancellationToken cancellationToken);
}
