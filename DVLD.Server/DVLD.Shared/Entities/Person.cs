using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string NationalNo { get; set; }
        public string FName { get; set; }
        public string SecName { get; set; }
        public string ThName { get; set; }
        public string LName { get; set; }
        public DateTime Date { get; set; }
        public short Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationaltyId { get; set; }
        public string ImagePath { get; set; }
        public Person()
        {
            PersonId = -1;
            NationalNo = string.Empty;
            FName = string.Empty;
            SecName = string.Empty;
            ThName = string.Empty;
            LName = string.Empty;
            Date = DateTime.Now;
            Gendor = 0;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationaltyId = -1;
            ImagePath = string.Empty;
        }

        public Person(int id, string nationalNo, string fname, string secname, string thName, string lName, DateTime date, short gendor,
            string address, string phone, string email, int nationaltyId, string path)
        {
            PersonId = id;
            NationalNo = nationalNo;
            FName = fname;
            SecName = secname;
            ThName = thName;
            LName = lName;
            Date = date;
            Gendor = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationaltyId = nationaltyId;
            ImagePath = path;
        }
    }
}
