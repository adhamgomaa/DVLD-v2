using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;

namespace DVLD.Business.Implementations
{
    public sealed class ApplicationService(IApplicationData applicationData) : IApplicationService
    {
        public async Task<bool> AddNewAppAsync(Application newApp, CancellationToken cancellationToken)
        {
            newApp.AppID = await applicationData.AddNewAppAsync(newApp, cancellationToken);
            return newApp.AppID != -1;
        }

        public async Task<bool> UpdateAppAsync(Application updateApp, CancellationToken cancellationToken)
        {
            return await applicationData.UpdateAppAsync(updateApp, cancellationToken);
        }

        public async Task<Application?> FindAppAsync(int id, CancellationToken cancellationToken)
        {
            Application? app = await applicationData.FindAppAsync(id, cancellationToken);
            if (app != null)
                return app;
            return null;
        }

        public async Task<bool> DeleteAppAsync(int id, CancellationToken cancellationToken)
        {
            return await applicationData.DeleteAppAsync(id, cancellationToken);
        }
    }
}
