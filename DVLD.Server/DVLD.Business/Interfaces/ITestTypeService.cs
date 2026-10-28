using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface ITestTypeService
{
    Task<bool> UpdateAppTypesAsync(TestType updateType, CancellationToken cancellationToken);
    Task<TestType?> FindTypeAsync(TestTypeEnum typeID, CancellationToken cancellationToken);
    Task<List<TestType>> GetAllTypesAsync(CancellationToken cancellationToken);
}
