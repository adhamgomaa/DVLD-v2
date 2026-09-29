using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.People
{
    public class GetPersonDto
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
        public GetPersonDto()
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
    }
}
