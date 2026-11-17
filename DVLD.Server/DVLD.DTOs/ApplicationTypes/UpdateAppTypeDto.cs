using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.ApplicationTypes;
    public class UpdateAppTypeDto
    {
        [Required]
        public required string Title { get; set; }
        [Required]
        public decimal Fees { get; set; }
    }
