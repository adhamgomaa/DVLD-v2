using System;
using System.Collections.Generic;
using DVLD.Shared.Enums;

namespace DVLD.Shared.Models;

public partial class TestAppointment
{
    public int TestAppointmentId { get; set; }

    public TestTypeEnum TestTypeId { get; set; }

    public int LocalDrivingLicenseId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public decimal PaidFees { get; set; }

    public int CreatedByUserId { get; set; }

    public bool IsLocked { get; set; }

    public int? RetakeTestApplicationId { get; set; }

    public User CreatedByUser { get; set; } = null!;

    public LocalDrivingLicense LocalDrivingLicense { get; set; } = null!;

    public Application? RetakeTestApplication { get; set; }

    public TestType TestType { get; set; } = null!;

    public Test? Test { get; set; }
}
