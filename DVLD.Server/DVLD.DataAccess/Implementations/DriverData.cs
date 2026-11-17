using DVLD.DataAccess.Data;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess.Implementations
{
    public sealed class DriverData(AppDbContext context) : IDriverData
    {
        public async Task<int> AddNewDriverAsync(Driver newDriver, CancellationToken cancellationToken)
        {
            context.Drivers.Add(newDriver);
            await context.SaveChangesAsync(cancellationToken);
            return newDriver.DriverId;
        }

        public async Task<List<DriverView>> ListDriversAsync(CancellationToken cancellationToken)
        {
            var drivers = await context.DriverViews.AsNoTracking().ToListAsync(cancellationToken);
            return drivers;
        }

        public async Task<bool> IsPersonDriverAsync(int personId, CancellationToken cancellationToken)
        {
            bool isExist = await context.Drivers.AsNoTracking().AnyAsync(d => d.PersonId == personId, cancellationToken);
            return isExist;
        }

        public async Task<Driver?> FindDriverByPersonIdAsync(int personId, CancellationToken cancellationToken)
        {
            var driver = await context.Drivers.AsNoTracking().SingleOrDefaultAsync(d => d.PersonId == personId, cancellationToken);
            return driver;
        }

        public async Task<Driver?> FindDriverAsync(int driverId, CancellationToken cancellationToken)
        {
            var driver = await context.Drivers.AsNoTracking().SingleOrDefaultAsync(d => d.DriverId == driverId, cancellationToken);
            return driver;
        }
    }
}
