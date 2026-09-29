using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.People
{
    public class PeopleDto
    {
        public int PersonId { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public string Gendor { get; set; }
        public DateTime Date { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public PeopleDto()
        {
            PersonId = -1;
            NationalNo = string.Empty;
            FullName = string.Empty;
            Gendor = string.Empty;
            Date = DateTime.MinValue;
            Nationality = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
        }
    }
}
