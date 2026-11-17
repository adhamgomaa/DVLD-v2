using System;
using System.Collections.Generic;

namespace DVLD.Shared.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string NationalNo { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? ThirdName { get; set; }

    public string LastName { get; set; } = null!;

    public DateTime BirthOfDate { get; set; }

    public byte Gendor { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public int NationalityCountryById { get; set; }

    public string? ImagePath { get; set; }

    public ICollection<Application> Applications { get; set; } = new List<Application>();

    public User? User { get; set; }

    public Country NationalityCountryBy { get; set; } = null!;

    public Driver? Driver { get; set; }
}
