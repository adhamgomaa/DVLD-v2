using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;

namespace DVLD.Business.Implementations
{
    public sealed class DriverService(IDriverData driverData) : IDriverService
    {
        public async Task<bool> AddNewDriverAsync(Driver newDriver, CancellationToken cancellationToken)
        {
            await driverData.AddNewDriverAsync(newDriver, cancellationToken);
            return newDriver.DriverId != -1;
        }

        public Task<List<DriverView>> ListDriversAsync(CancellationToken cancellationToken) =>
            driverData.ListDriversAsync(cancellationToken);

        public Task<bool> IsPersonDriverAsync(int personId, CancellationToken cancellationToken) =>
            driverData.IsPersonDriverAsync(personId, cancellationToken);

        public Task<Driver?> FindDriverAsync(int personId, CancellationToken cancellationToken) =>
            driverData.FindDriverByPersonIdAsync(personId, cancellationToken);

        public Task<Driver?> FindDriverWithDriverIDAsync(int driverId, CancellationToken cancellationToken) =>
            driverData.FindDriverAsync(driverId, cancellationToken);
    }
}
