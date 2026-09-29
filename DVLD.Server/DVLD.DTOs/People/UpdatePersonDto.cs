using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.People
{
    public class UpdatePersonDto
    {
        [Required]
        public string NationalNo { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string SecName { get; set; }
        public string ThName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public short Gendor { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int NationaltyId { get; set; }
        public string ImagePath { get; set; }
        public UpdatePersonDto()
        {
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
