using DVLD.DTOs.TestAppointment;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public static class AppointmentMapper
    {
        public static AppointmentDto ToAppointmentDto(TestAppointment test)
        {
            return new AppointmentDto
            {
                AppointmentId = test.AppointmentId,
                Date = test.Date,
                IsLocked = test.IsLocked,
                Fees = test.Fees
            };
        }
        public static GetAppointmentDto ToGetDto(TestAppointment test)
        {
            return new GetAppointmentDto
            {
                AppointmentId = test.AppointmentId,
                RetakeApplicationId = test.RetakeApplicationId,
                Date = test.Date,
                IsLocked = test.IsLocked,
                LocalId = test.LocalId,
                TestTypeId = test.TestTypeId,
                Fees = test.Fees,
                UserId = test.UserId
            };
        }
        public static TestAppointment ToApp(CreateAppointmentDto createTest)
        {
            return new TestAppointment
            {
                RetakeApplicationId = createTest.RetakeApplicationId,
                Date = createTest.Date,
                LocalId= createTest.LocalId,
                TestTypeId = createTest.TestTypeId,
                Fees = createTest.Fees,
                UserId = createTest.UserId
            };
        }
    }
}
