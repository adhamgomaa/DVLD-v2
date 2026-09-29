using DVLD.DTOs.Applications;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public class ApplicationMapper
    {
        public static GetAppDto ToGetDto(Application app)
        {
            return new GetAppDto
            {
                AppID = app.AppID,
                PersonId = app.PersonId,
                AppDate = app.AppDate,
                AppStatus = app.AppStatus,
                Type = app.Type,
                Fees = app.Fees,
                StatusDate = app.StatusDate,
                UserId = app.UserId
            };
        }
        public static Application ToApp(CreateAppDto createApp)
        {
            return new Application
            {
                PersonId = createApp.PersonId,
                AppStatus = createApp.AppStatus,
                Type = createApp.Type,
                Fees = createApp.Fees,
                StatusDate = createApp.StatusDate,
                UserId = createApp.UserId
            };
        }
    }
}
