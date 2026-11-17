using DVLD.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.Applications;
    public class UpdateAppDto
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public AppTypeEnum Type { get; set; }
        [Required]
        public AppStatusEnum AppStatus { get; set; }
        [Required]
        public DateTime StatusDate { get; set; }
        [Required]
        public decimal Fees { get; set; }
        [Required]
        public int UserId { get; set; }
    }
