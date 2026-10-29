using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface IApplicationTypeData
{
    Task<ApplicationType?> FindTypesAsync(AppTypeEnum id, CancellationToken cancellationToken);
    Task<ApplicationType?> FindTypesAsync(string title, CancellationToken cancellationToken);
    Task<List<ApplicationType>> GetAllTypesAsync(CancellationToken cancellationToken);
    Task<bool> UpdateTypesAsync(ApplicationType updateTypes, CancellationToken cancellationToken);
}
