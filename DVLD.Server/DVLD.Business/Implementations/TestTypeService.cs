using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business.Implementations
{
    public sealed class TestTypeService(ITestTypeData testTypeData) : ITestTypeService
    {
        public async Task<bool> UpdateAppTypesAsync(TestType updateType, CancellationToken cancellationToken)
        {
            return await testTypeData.UpdateTypesAsync(updateType, cancellationToken);
        }

        public async Task<TestType?> FindTypeAsync(TestTypeEnum typeID, CancellationToken cancellationToken)
        {
            TestType? type = await testTypeData.FindTypesAsync(typeID, cancellationToken);
            if (type != null)
                return type;
            return null;
        }

        public async Task<List<TestType>> GetAllTypesAsync(CancellationToken cancellationToken)
        {
            return await testTypeData.GetAllTypesAsync(cancellationToken);
        }
    }
}
