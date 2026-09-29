using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class LicenseClass
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public int Length { get; set; }
        public decimal Fees { get; set; }

        public LicenseClass(int id, string className, string desc, int age, int length, decimal fees)
        {
            ClassId = id;
            ClassName = className;
            Description = desc;
            Age = age;
            Length = length;
            Fees = fees;
        }
    }
}
