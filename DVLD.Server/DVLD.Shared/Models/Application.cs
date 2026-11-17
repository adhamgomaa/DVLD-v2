using System;
using System.Collections.Generic;
using DVLD.Shared.Enums;

namespace DVLD.Shared.Models;

public partial class Application
{
    public int ApplicationId { get; set; }

    public int ApplicantPersonId { get; set; }

    public DateTime ApplicationDate { get; set; }

    public AppTypeEnum ApplicationTypeId { get; set; }

    /// <summary>
    /// 1-New 2-Cancelled 3-Completed
    /// </summary>
    public AppStatusEnum ApplicationStatus { get; set; }

    public DateTime LastStatusDate { get; set; }

    public decimal PaidFees { get; set; }

    public int CreatedByUserId { get; set; }

    public Person ApplicantPerson { get; set; } = null!;

    public ApplicationType ApplicationType { get; set; } = null!;

    public User CreatedByUser { get; set; } = null!;

    public ICollection<DetainedLicense> DetainedLicenses { get; set; } = new List<DetainedLicense>();

    public ICollection<InternationalLicense> InternationalLicenses { get; set; } = new List<InternationalLicense>();

    public ICollection<License> Licenses { get; set; } = new List<License>();

    public ICollection<LocalDrivingLicense> LocalDrivingLicenses { get; set; } = new List<LocalDrivingLicense>();

    public ICollection<TestAppointment> TestAppointments { get; set; } = new List<TestAppointment>();
}
