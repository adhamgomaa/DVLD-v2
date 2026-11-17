using DVLD.DTOs.Licenses;
using DVLD.Shared.Models;

namespace DVLD.API.Mappers
{
    public static class LicenseMapper
    {
        public static GetLicenseDto ToGetDto(License license)
        {
            return new GetLicenseDto
            {
                LicenseID = license.LicenseId,
                AppID = license.ApplicationId,
                DriverID = license.DriverId,
                ClassID = license.LicenseClassId,
                ExpiredDate = license.ExpirationDate,
                IsActive = license.IsActive,
                IssueDate = license.IssueDate,
                Fees = license.PaidFees,
                IssueReason = license.IssueReason,
                UserID = license.CreatedByUserId,
                Notes = license.Notes
            };
        }
        public static License ToLicense(CreateLicenseDto createLicense)
        {
            return new License
            {
                ApplicationId = createLicense.AppID,
                DriverId = createLicense.DriverID,
                LicenseClassId = createLicense.ClassID,
                ExpirationDate = createLicense.ExpiredDate,
                IsActive = createLicense.IsActive,
                IssueReason = createLicense.IssueReason,
                Notes = createLicense.Notes,
                CreatedByUserId = createLicense.UserID,
                PaidFees = createLicense.Fees
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
