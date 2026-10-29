using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business.Implementations
{
    public sealed class DriverService(IDriverData driverData) : IDriverService
    {
        public async Task<bool> AddNewDriverAsync(Driver newDriver, CancellationToken cancellationToken)
        {
            newDriver.DriverID = await driverData.AddNewDriverAsync(newDriver, cancellationToken);
            return newDriver.DriverID != -1;
        }

        public async Task<List<DriverInfo>> ListDriversAsync(CancellationToken cancellationToken)
        {
            return await driverData.ListDriversAsync(cancellationToken);
        }

        public async Task<bool> IsPersonDriverAsync(int personId, CancellationToken cancellationToken)
        {
            return await driverData.IsPersonDriverAsync(personId, cancellationToken);
        }

        public async Task<Driver?> FindDriverAsync(int personId, CancellationToken cancellationToken)
        {
            Driver? driver = await driverData.FindDriverByPersonIdAsync(personId, cancellationToken);
            if (driver != null)
                return driver;
            return null;
        }

        public async Task<Driver?> FindDriverWithDriverIDAsync(int driverId, CancellationToken cancellationToken)
        {
            Driver? driver = await driverData.FindDriverAsync(driverId, cancellationToken);
            if (driver != null)
                return driver;
            return null;
        }
    }
}
