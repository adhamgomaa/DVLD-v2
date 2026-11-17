using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.TestTypes;

public class TestTypesDto
{
    public TestTypeEnum TestTypeId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public decimal Fees { get; set; }
}

