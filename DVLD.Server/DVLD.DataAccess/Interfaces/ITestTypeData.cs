using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface ITestTypeData
{
    Task<TestType?> FindTypesAsync(TestTypeEnum id, CancellationToken cancellationToken);
    Task<List<TestType>> GetAllTypesAsync(CancellationToken cancellationToken);
    Task<bool> UpdateTypesAsync(TestType updateTypes, CancellationToken cancellationToken);
}
