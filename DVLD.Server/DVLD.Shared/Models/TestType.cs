using System;
using System.Collections.Generic;
using DVLD.Shared.Enums;

namespace DVLD.Shared.Models;

public partial class TestType
{
    public TestTypeEnum TestTypeId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Fees { get; set; }

    public ICollection<TestAppointment> TestAppointments { get; set; } = new List<TestAppointment>();
}
