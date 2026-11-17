using DVLD.DTOs.LocalLicense;
using DVLD.Shared.Models;

namespace DVLD.API.Mappers
{
    public static class LocalLicenseMapper
    {
        public static LocalLicenseDto ToLocalDto(LocalDrivingLicenseApplication local)
        {
            return new LocalLicenseDto
            {
                AppDate = local.ApplicationDate,
                AppId = local.LDLAppId,
                Status = local.Status,
                ClassName = local.DrivingClass,
                NationalNo = local.NationalNo,
                PassedTest = local.PassedTests,
                FullName = local.FullName
            };
        }

        public static GetLocalLicenseDto ToGetDto(LocalDrivingLicense license)
        {
            return new GetLocalLicenseDto
            {
                AppId = license.ApplicationId,
                ClassId = license.LicenseClassId,
                LocalId = license.LocalDrivingLicenseApplicationId
            };
        }

        public static LocalDrivingLicense ToLicense(CreateLocalLicenseDto createLicense)
        {
            return new LocalDrivingLicense
            {
                Application = new Application
                {
                    ApplicantPersonId = createLicense.PersonId,
                    LastStatusDate = createLicense.StatusDate,
                    ApplicationStatus = createLicense.AppStatus,
                    ApplicationTypeId = createLicense.Type,
                    PaidFees = createLicense.Fees,
                    CreatedByUserId = createLicense.UserId
                },
                LicenseClassId = createLicense.ClassId,
            };
        }
    }
}
