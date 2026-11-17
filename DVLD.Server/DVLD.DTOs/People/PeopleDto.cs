namespace DVLD.DTOs.People;

    public class PeopleDto
    {
        public int PersonId { get; set; }
        public required string NationalNo { get; set; }
        public required string FullName { get; set; }
        public required string Gender { get; set; }
        public DateTime Date { get; set; }
        public required string Nationality { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
    }
