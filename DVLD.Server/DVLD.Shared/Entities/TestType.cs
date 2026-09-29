using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class TestType
    {
        public TestTypeEnum TestTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public TestType(TestTypeEnum Id, string title, string description, decimal fees)
        {
            TestTypeId = Id;
            Title = title;
            Description = description;
            Fees = fees;
        }
    }
}
