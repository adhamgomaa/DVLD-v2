using DVLD.DTOs.Drivers;
using DVLD.Shared.Models;

namespace DVLD.API.Mappers
{
    public class DriverMapper
    {
        public static DriverDto ToDriverDto(DriverView driver)
        {
            return new DriverDto
            {
                PersonId = driver.PersonId,
                NationalNo = driver.NationalNo,
                Date = driver.Date,
                DriverId = driver.DriverId,
                FullName = driver.FullName,
                ActiveLicense = driver.ActiveLicenses
            };
        }
        
        public static GetDriverDto ToGetDto(Driver driver)
        {
            return new GetDriverDto
            {
                DriverID = driver.DriverId,
                CreatedDate = driver.CreatedDate,
                PersonID = driver.PersonId,
                UserID = driver.CreatedByUserId
            };
        }
        public static Driver ToDriver(CreateDriverDto createDriver)
        {
            return new Driver
            {
                PersonId = createDriver.PersonID,
                CreatedByUserId = createDriver.UserID
            };
        }
    }
}
