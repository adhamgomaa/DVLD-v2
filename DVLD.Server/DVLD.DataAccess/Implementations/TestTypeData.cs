using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;
using System.Data;
using DVLD.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.DataAccess.Implementations
{
    public sealed class TestTypeData(AppDbContext context) : ITestTypeData
    {
        public async Task<TestType?> FindTypesAsync(TestTypeEnum id, CancellationToken cancellationToken)
        {
            var type = await context.TestTypes.FindAsync([(int)id], cancellationToken);
            return type;
        }
        public async Task<List<TestType>> GetAllTypesAsync(CancellationToken cancellationToken)
        {
            var types = await context.TestTypes.AsNoTracking()
                        .Select(t => new TestType
                        {
                            TestTypeId = t.TestTypeId,
                            Title = t.Title,
                            Description = t.Description,
                            Fees = t.Fees
                        }).ToListAsync(cancellationToken);
            return types;
        }
        public async Task<bool> UpdateTypesAsync(TestType updateTypes, CancellationToken cancellationToken)
        {
            var type = await context.TestTypes.FindAsync([updateTypes.TestTypeId], cancellationToken);
            if(type is null)
                return false;
            type.Description = updateTypes.Description;
            type.Title = updateTypes.Title;
            type.Fees = updateTypes.Fees;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
