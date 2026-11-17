using DVLD.DTOs.LicenseClass;
using DVLD.Shared.Models;

namespace DVLD.API.Mappers
{
    public static class LicenseClassMapper
    {
        public static LicenseClassDto ToClassDto(LicenseClass license)
        {
            return new LicenseClassDto
            {
                Length = license.DefaultValidityLength,
                Age = license.MinimumAllowedAge,
                Description = license.ClassDescription,
                ClassId = license.LicenseClassId,
                ClassName = license.ClassName,
                Fees = license.ClassFees
            };
        }
    }
}
