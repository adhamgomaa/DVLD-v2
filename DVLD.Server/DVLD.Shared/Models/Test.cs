using System;
using System.Collections.Generic;

namespace DVLD.Shared.Models;

public partial class Test
{
    public int TestId { get; set; }

    public int TestAppointmentId { get; set; }

    public bool TestResult { get; set; }

    public string? Notes { get; set; }

    public int CreatedByUserId { get; set; }

    public User CreatedByUser { get; set; } = null!;

    public TestAppointment TestAppointment { get; set; } = null!;
}
