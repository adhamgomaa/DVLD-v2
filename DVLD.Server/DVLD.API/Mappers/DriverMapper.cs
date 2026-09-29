using DVLD.DTOs.Drivers;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public class DriverMapper
    {
        public static DriverDto ToDriverDto(DriverInfo driver)
        {
            return new DriverDto
            {
                PersonId = driver.PersonId,
                NationalNo = driver.NationalNo,
                Date = driver.Date,
                DriverId = driver.DriverId,
                FullName = driver.FullName,
                ActiveLicense = driver.ActiveLicense
            };
        }
        
        public static GetDriverDto ToGetDto(Driver driver)
        {
            return new GetDriverDto
            {
                DriverID = driver.DriverID,
                CreatedDate = driver.CreatedDate,
                PersonID = driver.PersonID,
                UserID = driver.UserID
            };
        }
        public static Driver ToDriver(CreateDriverDto createdriver)
        {
            return new Driver
            {
                PersonID = createdriver.PersonID,
                UserID = createdriver.UserID
            };
        }
    }
}
