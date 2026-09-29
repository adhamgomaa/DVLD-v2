using DVLD.DataAccess;
using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class DriverService
    {
        public static async Task<bool> AddNewDriverAsync(Driver newDriver)
        {
            newDriver.DriverID = await DriverData.AddNewDriverAsync(newDriver);
            return newDriver.DriverID != -1;
        }

        public static async Task<List<DriverInfo>> ListDriversAsync()
        {
            return await DriverData.ListDriversAsync();
        }

        public static async Task<bool> IsPersonDriverAsync(int personId)
        {
            return await DriverData.IsPersonDriverAsync(personId);
        }

        public static async Task<Driver?> FindDriverAsync(int personId)
        {
            Driver? driver = await DriverData.FindDriverByPersonIdAsync(personId);
            if (driver != null)
                return driver;
            return null;
        }

        public static async Task<Driver?> FindDriverWithDriverIDAsync(int driverId)
        {
            Driver? driver = await DriverData.FindDriverAsync(driverId);
            if (driver != null)
                return driver;
            return null;
        }
    }
}
