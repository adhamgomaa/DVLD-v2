using DVLD.DTOs.Applications;
using DVLD.Shared.Models;

namespace DVLD.API.Mappers
{
    public class ApplicationMapper
    {
        public static GetAppDto ToGetDto(Application app)
        {
            return new GetAppDto
            {
                AppID = app.ApplicationId,
                PersonId = app.ApplicantPersonId,
                AppDate = app.ApplicationDate,
                AppStatus = app.ApplicationStatus,
                Type = app.ApplicationTypeId,
                Fees = app.PaidFees,
                StatusDate = app.LastStatusDate,
                UserId = app.CreatedByUserId
            };
        }
        public static Application ToApp(CreateAppDto createApp)
        {
            return new Application
            {
                ApplicantPersonId = createApp.PersonId,
                ApplicationStatus = createApp.AppStatus,
                ApplicationTypeId = createApp.Type,
                PaidFees = createApp.Fees,
                LastStatusDate = createApp.StatusDate,
                CreatedByUserId = createApp.UserId
            };
        }
    }
}
