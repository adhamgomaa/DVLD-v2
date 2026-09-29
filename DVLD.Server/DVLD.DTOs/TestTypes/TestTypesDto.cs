using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.TestTypes
{
    public class TestTypesDto
    {
        public TestTypeEnum TestTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public TestTypesDto()
        {
            TestTypeId = TestTypeEnum.VisionTest;
            Title = string.Empty;
            Description = string.Empty;
            Fees = 0;
        }
    }
}
