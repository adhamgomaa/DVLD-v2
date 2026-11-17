using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.Drivers;
    public class CreateDriverDto
    {
        [Required]
        public int PersonID { get; set; }
        [Required]
        public int UserID { get; set; }
    }
