using DVLD.DataAccess.Interfaces;
using System.Data;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;
using DVLD.DataAccess.Data;

namespace DVLD.DataAccess.Implementations
{
    public sealed class ApplicationData(AppDbContext context) : IApplicationData
    {
        public async Task<int> AddNewAppAsync(Application newApplication, CancellationToken cancellationToken)
        {
            context.Applications.Add(newApplication);
            await context.SaveChangesAsync(cancellationToken);
            return newApplication.ApplicationId;
        }

        public async Task<bool> UpdateAppAsync(Application UpdateApplication, CancellationToken cancellationToken)
        {
            var app = await context.Applications.FindAsync([UpdateApplication.ApplicationId], cancellationToken);
            if(app is null)
                return false;
            app.ApplicantPersonId = UpdateApplication.ApplicantPersonId;
            app.ApplicationDate = UpdateApplication.ApplicationDate;
            app.ApplicationStatus = UpdateApplication.ApplicationStatus;
            app.ApplicationTypeId = UpdateApplication.ApplicationTypeId;
            app.CreatedByUserId = UpdateApplication.CreatedByUserId;
            app.LastStatusDate = UpdateApplication.LastStatusDate;
            app.PaidFees = app.PaidFees;

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteAppAsync(int appId, CancellationToken cancellationToken)
        {
            var app = await context.Applications.FindAsync([appId], cancellationToken);
            if(app is null)
                return false;
            context.Applications.Remove(app);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
        public async Task<Application?> FindAppAsync(int id, CancellationToken cancellationToken)
        {
            var app = await context.Applications.FindAsync([id], cancellationToken);
            return app;
        }
    }
}
