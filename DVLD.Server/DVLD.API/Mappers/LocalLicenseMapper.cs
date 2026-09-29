using DVLD.DTOs.LocalLicense;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public static class LocalLicenseMapper
    {
        public static LocalLicenseDto ToLocalDto(LocalDrivingApplications local)
        {
            return new LocalLicenseDto
            {
                AppDate = local.AppDate,
                AppId = local.AppId,
                Status = local.Status,
                ClassName = local.ClassName,
                NationalNo = local.NationalNo,
                PassedTest = local.PassedTest,
                FullName = local.FullName
            };
        }

        public static GetLocalLicenseDto ToGetDto(LocalLicense license)
        {
            return new GetLocalLicenseDto
            {
                AppId = license.AppId,
                ClassId = license.ClassId,
                LocalId = license.LocalId
            };
        }

        public static LocalLicense ToLicense(CreateLocalLicenseDto createLicense)
        {
            return new LocalLicense
            {
                PersonId = createLicense.PersonId,
                StatusDate = createLicense.StatusDate,
                AppStatus = createLicense.AppStatus,
                Type = createLicense.Type,
                ClassId = createLicense.ClassId,
                Fees = createLicense.Fees,
                UserId = createLicense.UserId,
            };
        }
    }
}
