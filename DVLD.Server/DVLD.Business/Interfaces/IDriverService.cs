using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface IDriverService
{
    Task<bool> AddNewDriverAsync(Driver newDriver, CancellationToken cancellationToken);
    Task<List<DriverView>> ListDriversAsync(CancellationToken cancellationToken);
    Task<bool> IsPersonDriverAsync(int personId, CancellationToken cancellationToken);
    Task<Driver?> FindDriverAsync(int personId, CancellationToken cancellationToken);
    Task<Driver?> FindDriverWithDriverIDAsync(int driverId, CancellationToken cancellationToken);
}
