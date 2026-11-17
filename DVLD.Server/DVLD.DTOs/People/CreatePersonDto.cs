using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.People
{
    public class CreatePersonDto
    {
        [Required]
        public required string NationalNo { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string SecondName { get; set; }
        public required string ThirdName { get; set; }
        [Required]
        public required string LName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public byte Gender { get; set; }
        [Required]
        public required string Address { get; set; }
        [Required]
        [Phone]
        public required string Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public int NationalityId { get; set; }
        public string? ImagePath { get; set; }
    }
}
