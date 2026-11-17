namespace DVLD.DTOs.LicenseClass;
    public class LicenseClassDto
    {
        public int ClassId { get; set; }
        public required string ClassName { get; set; }
        public required string Description { get; set; }
        public int Age { get; set; }
        public int Length { get; set; }
        public decimal Fees { get; set; }
    }
