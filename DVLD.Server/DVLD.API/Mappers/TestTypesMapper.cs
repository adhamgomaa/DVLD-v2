using DVLD.DTOs.ApplicationTypes;
using DVLD.DTOs.TestTypes;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public static class TestTypesMapper
    {
        public static TestTypesDto ToTypesDto(TestType type)
        {
            return new TestTypesDto
            {
                TestTypeId = type.TestTypeId,
                Title = type.Title,
                Description = type.Description,
                Fees = type.Fees
            };
        }
    }
}
