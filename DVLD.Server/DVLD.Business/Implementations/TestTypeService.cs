using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.Business.Implementations
{
    public sealed class TestTypeService(ITestTypeData testTypeData) : ITestTypeService
    {
        public Task<bool> UpdateAppTypesAsync(TestType updateType, CancellationToken cancellationToken) =>
            testTypeData.UpdateTypesAsync(updateType, cancellationToken);

        public Task<TestType?> FindTypeAsync(TestTypeEnum typeID, CancellationToken cancellationToken) =>
            testTypeData.FindTypesAsync(typeID, cancellationToken);

        public Task<List<TestType>> GetAllTypesAsync(CancellationToken cancellationToken) =>
            testTypeData.GetAllTypesAsync(cancellationToken);
    }
}
