using DVLD.DTOs.DetainLicense;
using DVLD.Shared.Models;

namespace DVLD.API.Mappers
{
    public static class DetainLicenseMapper
    {
        public static GetDetainDto ToGetDto(DetainedLicense license)
        {
            return new GetDetainDto
            {
                DetainID = license.DetainId,
                DetainDate = license.DetainDate,
                IsRelease = license.IsReleased,
                ReleaseAppId = license.ReleaseApplicationId,
                ReleaseByUserId = license.ReleasedByUserId,
                ReleaseDate = license.ReleaseDate,
                LicenseID = license.LicenseId,
                Fees = license.DetainFees,
                UserID = license.CreatedByUserId
            };
        }

        public static DetainedLicense ToLicense(CreateDetainLicenseDto createLicense)
        {
            return new DetainedLicense
            {
                LicenseId = createLicense.LicenseID,
                CreatedByUserId = createLicense.UserID,
                DetainFees = createLicense.Fees
            };
        }

        public static DetainLicenseDto ToLicenseDto(DetainedLicenseInfo license)
        {
            return new DetainLicenseDto
            {
                ReleaseAppId = license.ReleaseApplicationId,
                ReleaseDate = license.ReleaseDate,
                DetainDate = license.DetainDate,
                DetainFees = license.DetainFees,
                DetainId = license.DetainId,
                FullName = license.FullName,
                IsReleased = license.IsReleased,
                LicenseId = license.LicenseId,
                NationalNo = license.NationalNo
            };
        }
    }
}
