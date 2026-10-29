using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface IApplicationTypeService
{
    Task<bool> UpdateAppTypesAsync(ApplicationType updateTypes, CancellationToken cancellationToken);
    Task<ApplicationType?> FindTypeAsync(AppTypeEnum typeID, CancellationToken cancellationToken);
    Task<ApplicationType?> FindTypeAsync(string title, CancellationToken cancellationToken);
    Task<List<ApplicationType>> GetAllTypesAsync(CancellationToken cancellationToken);
}
