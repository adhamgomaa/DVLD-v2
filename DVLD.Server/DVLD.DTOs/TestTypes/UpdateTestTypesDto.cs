using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.TestTypes;

public class UpdateTestTypesDto
{
    [Required]
    public required string Title { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public decimal Fees { get; set; }
}

