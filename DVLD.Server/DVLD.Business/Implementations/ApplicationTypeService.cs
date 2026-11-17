using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.Business.Implementations
{
    public sealed class ApplicationTypeService(IApplicationTypeData applicationTypeData) : IApplicationTypeService
    {
        public async Task<bool> UpdateAppTypesAsync(ApplicationType updateTypes, CancellationToken cancellationToken)
        {
            return await applicationTypeData.UpdateTypesAsync(updateTypes, cancellationToken);
        }

        public Task<ApplicationType?> FindTypeAsync(AppTypeEnum typeID, CancellationToken cancellationToken) =>
            applicationTypeData.FindTypesAsync(typeID, cancellationToken);

        public Task<ApplicationType?> FindTypeAsync(string title, CancellationToken cancellationToken) =>
            applicationTypeData.FindTypesAsync(title, cancellationToken);
        public Task<List<ApplicationType>> GetAllTypesAsync(CancellationToken cancellationToken) =>
            applicationTypeData.GetAllTypesAsync(cancellationToken);
    }
}
