using DVLD.DTOs.Licenses;
using DVLD.DTOs.LocalLicense;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public static class LicenseMapper
    {
        public static GetLicenseDto ToGetDto(License license)
        {
            return new GetLicenseDto
            {
                LicenseID = license.LicenseID,
                AppID = license.AppID,
                DriverID = license.DriverID,
                ClassID = license.ClassID,
                ExpiredDate = license.ExpiredDate,
                IsActive = license.IsActive,
                IssueDate = license.IssueDate,
                Fees = license.Fees,
                IssueReason = license.IssueReason,
                UserID = license.UserID,
                Notes = license.Notes
            };
        }
        public static License ToLicense(CreateLicenseDto createLicense)
        {
            return new License
            {
                AppID = createLicense.AppID,
                DriverID = createLicense.DriverID,
                ClassID = createLicense.ClassID,
                ExpiredDate = createLicense.ExpiredDate,
                IsActive = createLicense.IsActive,
                IssueReason = createLicense.IssueReason,
                Notes = createLicense.Notes,
                UserID = createLicense.UserID,
                Fees = createLicense.Fees
            };
        }

        public static LicenseHistoryDto ToLicenseDto(LicenseHistory license)
        {
            return new LicenseHistoryDto
            {
                AppID= license.AppID,
                IsActive= license.IsActive,
                ExpirationDate = license.ExpirationDate,
                LicenseID = license.LicenseID,
                IssueDate= license.IssueDate,
                ClassName = license.ClassName
            };
        }
    }
}
