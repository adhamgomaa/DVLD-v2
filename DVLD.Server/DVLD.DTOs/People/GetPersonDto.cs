namespace DVLD.DTOs.People;
    public class GetPersonDto
    {
        public int PersonId { get; set; }
        public required string NationalNo { get; set; }
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public string? ThirdName { get; set; }
        public required string LastName { get; set; }
        public DateTime Date { get; set; }
        public required string Gender { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
        public int NationalityId { get; set; }
        public string? ImagePath { get; set; }
    }
