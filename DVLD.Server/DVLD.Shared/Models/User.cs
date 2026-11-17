using System;
using System.Collections.Generic;

namespace DVLD.Shared.Models;

public partial class User
{
    public int UserId { get; set; }

    public int PersonId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public ICollection<Application> Applications { get; set; } = new List<Application>();

    public ICollection<DetainedLicense> DetainedLicenseCreatedByUsers { get; set; } = new List<DetainedLicense>();

    public ICollection<DetainedLicense> DetainedLicenseReleasedByUsers { get; set; } = new List<DetainedLicense>();

    public ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    public ICollection<InternationalLicense> InternationalLicenses { get; set; } = new List<InternationalLicense>();

    public ICollection<License> Licenses { get; set; } = new List<License>();

    public Person Person { get; set; } = null!;

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public ICollection<TestAppointment> TestAppointments { get; set; } = new List<TestAppointment>();

    public ICollection<Test> Tests { get; set; } = new List<Test>();
}
