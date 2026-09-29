using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class PeopleInfo
    {
        public int PersonId { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public string Gendor { get; set; }
        public DateTime Date { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public PeopleInfo(int personId, string nationalNo, string fullName, string gendor, DateTime date, string nationality, string phone, string email)
        {
            PersonId = personId;
            NationalNo = nationalNo;
            FullName = fullName;
            Gendor = gendor;
            Date = date;
            Nationality = nationality;
            Phone = phone;
            Email = email;
        }
    }
}
