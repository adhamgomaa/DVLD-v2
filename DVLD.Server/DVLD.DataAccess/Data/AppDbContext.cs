using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Data;

public partial class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationType> ApplicationTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DetainedLicense> DetainedLicenses { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DriverView> DriverViews { get; set; }

    public virtual DbSet<InternationalLicense> InternationalLicenses { get; set; }

    public virtual DbSet<License> Licenses { get; set; }

    public virtual DbSet<LicenseClass> LicenseClasses { get; set; }

    public virtual DbSet<LocalDrivingLicense> LocalDrivingLicenses { get; set; }

    public virtual DbSet<LocalDrivingLicenseApplication> LocalDrivingLicenseApplications { get; set; }

    public virtual DbSet<LoginAttempt> LoginAttempts { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TestAppointment> TestAppointments { get; set; }

    public virtual DbSet<TestType> TestTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AI");

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK_Application");

            entity.HasIndex(e => e.ApplicantPersonId, "IX_Applications_ApplicantPersonID");

            entity.HasIndex(e => e.ApplicationTypeId, "IX_Applications_ApplicationTypeID");

            entity.HasIndex(e => e.ApplicationStatus, "IX_Applications_Status");

            entity.HasIndex(e => e.CreatedByUserId, "IX_Applications_UserID");

            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.ApplicantPersonId).HasColumnName("ApplicantPersonID");
            entity.Property(e => e.ApplicationDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ApplicationStatus)
                .HasConversion<byte>()
                .HasDefaultValue(AppStatusEnum.New)
                .HasComment("1-New 2-Cancelled 3-Completed");
            entity.Property(e => e.ApplicationTypeId)
                .HasColumnName("ApplicationTypeID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.LastStatusDate).HasColumnType("datetime");
            entity.Property(e => e.PaidFees).HasColumnType("smallmoney");

            entity.HasOne(d => d.ApplicantPerson).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicantPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_People");

            entity.HasOne(d => d.ApplicationType).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_ApplicationTypes");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Applications)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Users");
        });

        modelBuilder.Entity<ApplicationType>(entity =>
        {
            entity.HasKey(e => e.ApplicationTypeId);
            entity.Property(e => e.ApplicationTypeId)
                .HasColumnName("ApplicationTypeID");
            entity.Property(e => e.Fees).HasColumnType("smallmoney");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CountryName).HasMaxLength(50);
        });

        modelBuilder.Entity<DetainedLicense>(entity =>
        {
            entity.HasKey(e => e.DetainId);

            entity.HasIndex(e => e.LicenseId, "IX_DetainedLicenses_LicenseID");

            entity.HasIndex(e => e.CreatedByUserId, "IX_DetainedLicenses_UserID");

            entity.Property(e => e.DetainId).HasColumnName("DetainID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.DetainDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            entity.Property(e => e.DetainFees).HasColumnType("smallmoney");
            entity.Property(e => e.LicenseId).HasColumnName("LicenseID");
            entity.Property(e => e.ReleaseApplicationId).HasColumnName("ReleaseApplicationID");
            entity.Property(e => e.ReleaseDate).HasColumnType("datetime").HasDefaultValue(null);
            entity.Property(e => e.ReleasedByUserId).HasColumnName("ReleasedByUserID");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.DetainedLicenseCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetainedLicenses_Users");

            entity.HasOne(d => d.License).WithMany(p => p.DetainedLicenses)
                .HasForeignKey(d => d.LicenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetainedLicenses_Licenses");

            entity.HasOne(d => d.ReleaseApplication).WithMany(p => p.DetainedLicenses)
                .HasForeignKey(d => d.ReleaseApplicationId)
                .HasConstraintName("FK_DetainedLicenses_Application");

            entity.HasOne(d => d.ReleasedByUser).WithMany(p => p.DetainedLicenseReleasedByUsers)
                .HasForeignKey(d => d.ReleasedByUserId)
                .HasConstraintName("FK_DetainedLicenses_Users1");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK_Driver");

            entity.HasIndex(e => e.CreatedByUserId, "IX_Drivers_UserID");
            entity.HasIndex(e => e.PersonId, "UQ_Drivers_PersonID").IsUnique();

            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Driver_Users");

            entity.HasOne(d => d.Person).WithOne(p => p.Driver)
                .HasForeignKey<Driver>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Driver_People");
        });

        modelBuilder.Entity<DriverView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Driver_View");

            entity.Property(e => e.ActiveLicenses).HasColumnName("Active Licenses");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DriverId).HasColumnName("Driver ID");
            entity.Property(e => e.FullName)
                .HasMaxLength(83)
                .HasColumnName("Full Name");
            entity.Property(e => e.NationalNo)
                .HasMaxLength(20)
                .HasColumnName("National No.");
            entity.Property(e => e.PersonId).HasColumnName("Person ID");
        });

        modelBuilder.Entity<InternationalLicense>(entity =>
        {
            entity.HasKey(e => e.InternationalLicenseId);

            entity.HasIndex(e => e.DriverId, "IX_InternationalLicenses_DriverID");

            entity.HasIndex(e => e.IssuedUsingLocalLicenseId, "IX_InternationalLicenses_LicenseID");

            entity.Property(e => e.InternationalLicenseId).HasColumnName("InternationalLicenseID");
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IssueDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IssuedUsingLocalLicenseId).HasColumnName("IssuedUsingLocalLicenseID");

            entity.HasOne(d => d.Application).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Application");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Users");

            entity.HasOne(d => d.Driver).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Driver");

            entity.HasOne(d => d.IssuedUsingLocalLicense).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.IssuedUsingLocalLicenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Licenses");
        });

        modelBuilder.Entity<License>(entity =>
        {
            entity.HasKey(e => e.LicenseId);

            entity.HasIndex(e => e.DriverId, "IX_Licenses_DriverID");

            entity.HasIndex(e => e.LicenseClassId, "IX_Licenses_LicenseClassID");

            entity.Property(e => e.LicenseId).HasColumnName("LicenseID");
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IssueDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IssueReason)
                .HasConversion<byte>()
                .HasComment("1-FirstTime, 2-Renew, 3-Replacement for a Damaged, 4- Replacement for a Lost");
            entity.Property(e => e.LicenseClassId).HasColumnName("LicenseClassID");
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.PaidFees).HasColumnType("smallmoney");

            entity.HasOne(d => d.Application).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_Application");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_Users");

            entity.HasOne(d => d.Driver).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_Driver");

            entity.HasOne(d => d.LicenseClass).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.LicenseClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_LicenseClass");
        });

        modelBuilder.Entity<LicenseClass>(entity =>
        {
            entity.HasKey(e => e.LicenseClassId).HasName("PK_LicenseClass");

            entity.Property(e => e.LicenseClassId).HasColumnName("LicenseClassID");
            entity.Property(e => e.ClassDescription).HasMaxLength(255);
            entity.Property(e => e.ClassFees).HasColumnType("smallmoney");
            entity.Property(e => e.ClassName).HasMaxLength(255);
        });

        modelBuilder.Entity<LocalDrivingLicense>(entity =>
        {
            entity.HasKey(e => e.LocalDrivingLicenseApplicationId).HasName("PK_LocalDrivingLicense");

            entity.Property(e => e.LocalDrivingLicenseApplicationId).HasColumnName("LocalDrivingLicenseApplicationID");
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.LicenseClassId).HasColumnName("LicenseClassID");

            entity.HasOne(d => d.Application).WithMany(p => p.LocalDrivingLicenses)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocalDrivingLicense_Application");

            entity.HasOne(d => d.LicenseClass).WithMany(p => p.LocalDrivingLicenses)
                .HasForeignKey(d => d.LicenseClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocalDrivingLicense_LicenseClass");
        });

        modelBuilder.Entity<LocalDrivingLicenseApplication>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("LocalDrivingLicenseApplications");

            entity.Property(e => e.ApplicationDate).HasColumnType("datetime");
            entity.Property(e => e.DrivingClass)
                .HasMaxLength(255)
                .HasColumnName("Driving Class");
            entity.Property(e => e.FullName)
                .HasMaxLength(83)
                .HasColumnName("Full Name");
            entity.Property(e => e.LDLAppId).HasColumnName("L.D.L.AppID");
            entity.Property(e => e.NationalNo)
                .HasMaxLength(20)
                .HasColumnName("National No.");
            entity.Property(e => e.PassedTests).HasColumnName("Passed Tests");
            entity.Property(e => e.Status)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LoginAttempt>(entity =>
        {
            entity.HasKey(e => e.LoginAttemptId);

            entity.Property(e => e.AttemptedUserName).HasMaxLength(256);
            entity.Property(e => e.ClientIpAddress)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.HasIndex(e => e.NationalNo, "IX_People_NationalNumber");

            entity.HasIndex(e => e.NationalNo, "UQ_NationalNo").IsUnique();

            entity.HasIndex(e => e.Email, "UQ_People_Email").IsUnique();

            entity.HasIndex(e => e.NationalNo, "UQ_People_NationalNumber").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ_People_Phone").IsUnique();

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.BirthOfDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.ImagePath).HasMaxLength(500);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.NationalNo).HasMaxLength(20);
            entity.Property(e => e.NationalityCountryById).HasColumnName("NationalityCountryByID");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.SecondName).HasMaxLength(20);
            entity.Property(e => e.ThirdName).HasMaxLength(20);

            entity.HasOne(d => d.NationalityCountryBy).WithMany(p => p.People)
                .HasForeignKey(d => d.NationalityCountryById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_People_Countries");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.RefreshTokenId);

            entity.HasIndex(e => e.TokenFamilyId, "IX_RefreshTokens_TokenFamilyId").HasFillFactor(100);

            entity.HasIndex(e => new { e.UserId, e.ExpiresAt }, "IX_RefreshTokens_UserId_Active")
                .HasFilter("([RevokedAt] IS NULL)")
                .HasFillFactor(100);

            entity.HasIndex(e => e.TokenHash, "UQ_RefreshTokens_TokenHash").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.ExpiresAt).HasPrecision(0);
            entity.Property(e => e.RevokedAt).HasPrecision(0);
            entity.Property(e => e.TokenFamilyId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TokenHash)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.ReplacedByToken).WithMany(p => p.InverseReplacedByToken)
                .HasForeignKey(d => d.ReplacedByTokenId)
                .HasConstraintName("FK_RefreshTokens_ReplacedBy");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RefreshTokens_Users");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.Property(e => e.TestId).HasColumnName("TestID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.TestAppointmentId).HasColumnName("TestAppointmentID");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Tests)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tests_Users");

            entity.HasOne(d => d.TestAppointment).WithOne(p => p.Test)
                .HasForeignKey<Test>(d => d.TestAppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tests_TestAppointment");
        });

        modelBuilder.Entity<TestAppointment>(entity =>
        {
            entity.HasKey(e => e.TestAppointmentId).HasName("PK_TestAppointment");

            entity.HasIndex(e => e.TestTypeId, "IX_TestAppointments_TestTypeID");

            entity.Property(e => e.TestAppointmentId).HasColumnName("TestAppointmentID");
            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.LocalDrivingLicenseId).HasColumnName("LocalDrivingLicenseID");
            entity.Property(e => e.PaidFees).HasColumnType("smallmoney");
            entity.Property(e => e.RetakeTestApplicationId).HasColumnName("RetakeTestApplicationID");
            entity.Property(e => e.TestTypeId).HasColumnName("TestTypeID");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.TestAppointments)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestAppointment_Users");

            entity.HasOne(d => d.LocalDrivingLicense).WithMany(p => p.TestAppointments)
                .HasForeignKey(d => d.LocalDrivingLicenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestAppointment_LocalDrivingLicense");

            entity.HasOne(d => d.RetakeTestApplication).WithMany(p => p.TestAppointments)
                .HasForeignKey(d => d.RetakeTestApplicationId)
                .HasConstraintName("FK_TestAppointment_Application");

            entity.HasOne(d => d.TestType).WithMany(p => p.TestAppointments)
                .HasForeignKey(d => d.TestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestAppointment_TestType");
        });

        modelBuilder.Entity<TestType>(entity =>
        {
            entity.HasKey(e => e.TestTypeId).HasName("PK_TestType");

            entity.Property(e => e.TestTypeId).HasColumnName("TestTypeID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Fees).HasColumnType("smallmoney");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.HasIndex(e => e.Username, "UQ_username").IsUnique();
            entity.HasIndex(e => e.PersonId, "UQ_Users_PersonID").IsUnique();


            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.Person).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_People");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
