using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.LicenseClass
{
    public class LicenseClassDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public int Length { get; set; }
        public decimal Fees { get; set; }

        public LicenseClassDto()
        {
            ClassId = -1;
            ClassName = string.Empty;
            Description = string.Empty;
            Age = 0;
            Length = 0;
            Fees = 0;
        }
    }
}
