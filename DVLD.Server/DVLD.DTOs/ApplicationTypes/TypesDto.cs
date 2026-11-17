using DVLD.Shared.Enums;

namespace DVLD.DTOs.ApplicationTypes;
    public class TypesDto
    {
        public AppTypeEnum TypeID { get; set; }
        public required string Title { get; set; }
        public decimal Fees { get; set; }
    }
