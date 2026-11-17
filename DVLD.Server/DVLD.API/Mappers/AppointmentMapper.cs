using DVLD.DTOs.TestAppointment;
using DVLD.Shared.Models;

namespace DVLD.API.Mappers
{
    public static class AppointmentMapper
    {
        public static AppointmentDto ToAppointmentDto(TestAppointment test)
        {
            return new AppointmentDto
            {
                AppointmentId = test.TestAppointmentId,
                Date = test.AppointmentDate,
                IsLocked = test.IsLocked,
                Fees = test.PaidFees
            };
        }
        public static GetAppointmentDto ToGetDto(TestAppointment test)
        {
            return new GetAppointmentDto
            {
                AppointmentId = test.TestAppointmentId,
                RetakeApplicationId = test.RetakeTestApplicationId,
                Date = test.AppointmentDate,
                IsLocked = test.IsLocked,
                LocalId = test.LocalDrivingLicenseId,
                TestTypeId = test.TestTypeId,
                Fees = test.PaidFees,
                UserId = test.CreatedByUserId
            };
        }
        public static TestAppointment ToApp(CreateAppointmentDto createTest)
        {
            return new TestAppointment
            {
                RetakeTestApplicationId = createTest.RetakeApplicationId,
                AppointmentDate = createTest.Date,
                LocalDrivingLicenseId = createTest.LocalId,
                TestTypeId = createTest.TestTypeId,
                PaidFees = createTest.Fees,
                CreatedByUserId = createTest.UserId
            };
        }
    }
}
