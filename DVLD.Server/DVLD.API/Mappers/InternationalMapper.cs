using DVLD.DTOs.InternationalLicense;
using DVLD.Shared.Models;

namespace DVLD.API.Mappers
{
    public class InternationalMapper
    {
        public static InternationalLicenseDto ToLicenseDto(InternationalLicense license)
        {
            return new InternationalLicenseDto
            {
                AppID = license.ApplicationId,
                IsActive = license.IsActive,
                ExpirationDate = license.ExpirationDate,
                IssueDate = license.IssueDate,
                DriverID = license.DriverId,
                InternationalID = license.InternationalLicenseId,
                LocalLicenseID = license.IssuedUsingLocalLicenseId,
                UserID = license.CreatedByUserId
            };
        }
        public static InternationalHistoryDto ToLicenseHistoryDto(InternationalLicense license)
        {
            return new InternationalHistoryDto
            {
                AppID = license.ApplicationId,
                IsActive = license.IsActive,
                ExpirationDate = license.ExpirationDate,
                IssueDate = license.IssueDate,
                InternationalID = license.InternationalLicenseId,
                LocalLicenseID = license.IssuedUsingLocalLicenseId,
                UserID = license.CreatedByUserId
            };
        }

        public static InternationalLicense ToLicense(CreateInternationalLicenseDto createLicense)
        {
            return new InternationalLicense
            {
                Application = new Application
                {
                    ApplicantPersonId = createLicense.PersonId,
                    ApplicationStatus = createLicense.AppStatus,
                    ApplicationTypeId = createLicense.Type,
                    LastStatusDate = createLicense.StatusDate,
                    PaidFees = createLicense.Fees,
                    CreatedByUserId = createLicense.UserId
                },
                DriverId= createLicense.DriverID,
                ExpirationDate = createLicense.ExpirationDate,
                IsActive = createLicense.IsActive,
                IssuedUsingLocalLicenseId= createLicense.LocalLicenseID,
                CreatedByUserId = createLicense.UserId,
            };
        }
    }
}
