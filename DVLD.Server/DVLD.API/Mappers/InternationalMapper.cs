using DVLD.DTOs.DetainLicense;
using DVLD.DTOs.InternationalLicense;
using DVLD.DTOs.Licenses;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public class InternationalMapper
    {
        public static InternationalLicenseDto ToLicenseDto(InternationalLicense license)
        {
            return new InternationalLicenseDto
            {
                AppID = license.AppID,
                IsActive = license.IsActive,
                ExpirationDate = license.ExpirationDate,
                IssueDate = license.IssueDate,
                DriverID = license.DriverID,
                InternationalID = license.InternationalID,
                LocalLicenseID = license.LocalLicenseID,
                UserID = license.UserID
            };
        }
        public static InternationalHistoryDto ToLicenseHistoryDto(InternationalLicense license)
        {
            return new InternationalHistoryDto
            {
                AppID = license.AppID,
                IsActive = license.IsActive,
                ExpirationDate = license.ExpirationDate,
                IssueDate = license.IssueDate,
                InternationalID = license.InternationalID,
                LocalLicenseID = license.LocalLicenseID,
                UserID = license.UserID
            };
        }

        public static InternationalLicense ToLicense(CreateInternationalLicenseDto createLicense)
        {
            return new InternationalLicense
            {
                PersonId = createLicense.PersonId,
                AppStatus = createLicense.AppStatus,
                Type = createLicense.Type,
                StatusDate = createLicense.StatusDate,
                DriverID = createLicense.DriverID,
                ExpirationDate = createLicense.ExpirationDate,
                IsActive = createLicense.IsActive,
                LocalLicenseID= createLicense.LocalLicenseID,
                UserID = createLicense.UserID,
                Fees = createLicense.Fees
            };
        }
    }
}
