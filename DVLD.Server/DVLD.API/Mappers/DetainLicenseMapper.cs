using DVLD.DTOs.DetainLicense;
using DVLD.DTOs.Licenses;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public static class DetainLicenseMapper
    {
        public static GetDetainDto ToGetDto(DetainLicense license)
        {
            return new GetDetainDto
            {
                DetainID = license.DetainID,
                DetainDate = license.DetainDate,
                IsRelease = license.IsRelease,
                ReleaseAppId = license.ReleaseAppId,
                ReleaseByUserId = license.ReleaseByUserId,
                ReleaseDate = license.ReleaseDate,
                LicenseID = license.LicenseID,
                Fees = license.Fees,
                UserID = license.UserID
            };
        }

        public static DetainLicense ToLicense(CreateDetainLicenseDto createLicense)
        {
            return new DetainLicense
            {
                LicenseID = createLicense.LicenseID,
                UserID = createLicense.UserID,
                Fees = createLicense.Fees
            };
        }

        public static DetainLicenseDto ToLicenseDto(DetainLicenseInfo license)
        {
            return new DetainLicenseDto
            {
                ReleaseAppId = license.ReleaseAppId,
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
