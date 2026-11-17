using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;

namespace DVLD.Business.Implementations
{
    public sealed class ApplicationService(IApplicationData applicationData) : IApplicationService
    {
        public async Task<bool> AddNewAppAsync(Application newApp, CancellationToken cancellationToken)
        {
            await applicationData.AddNewAppAsync(newApp, cancellationToken);
            return newApp.ApplicationId != -1;
        }

        public Task<bool> UpdateAppAsync(Application updateApp, CancellationToken cancellationToken) =>
            applicationData.UpdateAppAsync(updateApp, cancellationToken);

        public Task<Application?> FindAppAsync(int id, CancellationToken cancellationToken) =>
            applicationData.FindAppAsync(id, cancellationToken);

        public Task<bool> DeleteAppAsync(int id, CancellationToken cancellationToken) =>
            applicationData.DeleteAppAsync(id, cancellationToken);
    }
}
