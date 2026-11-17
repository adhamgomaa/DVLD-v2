using System;
using System.Collections.Generic;
using DVLD.Shared.Enums;

namespace DVLD.Shared.Models;

public partial class ApplicationType
{
    public AppTypeEnum ApplicationTypeId { get; set; }

    public string Title { get; set; } = null!;

    public decimal Fees { get; set; }

    public ICollection<Application> Applications { get; set; } = new List<Application>();
}
