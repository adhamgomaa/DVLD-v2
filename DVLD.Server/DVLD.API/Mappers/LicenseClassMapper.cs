using DVLD.DTOs.LicenseClass;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public static class LicenseClassMapper
    {
        public static LicenseClassDto ToClassDto(LicenseClass license)
        {
            return new LicenseClassDto
            {
                Length = license.Length,
                Age = license.Age,
                Description = license.Description,
                ClassId = license.ClassId,
                ClassName = license.ClassName,
                Fees = license.Fees
            };
        }
    }
}
