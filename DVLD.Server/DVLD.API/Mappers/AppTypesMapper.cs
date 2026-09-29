using DVLD.DTOs.ApplicationTypes;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public static class AppTypesMapper
    {
        public static TypesDto ToTypesDto(ApplicationType type)
        {
            return new TypesDto
            {
                Title = type.Title,
                TypeID = type.TypeID,
                Fees = type.Fees
            };
        }
    }
}
