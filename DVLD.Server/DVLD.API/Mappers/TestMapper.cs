using DVLD.DTOs.Tests;
using DVLD.Shared.Models;

namespace DVLD.API.Mappers
{
    public class TestMapper
    {
        public static TestDto ToGetDto(Test test)
        {
            return new TestDto
            {
                TestId = test.TestId,
                AppointmentID = test.TestAppointmentId,
                Notes = test.Notes,
                Result = test.TestResult,
                UserId = test.CreatedByUserId
            };
        }
        public static Test ToTest(CreateTestDto createTest)
        {
            return new Test
            {
                TestAppointmentId = createTest.AppointmentID,
                Notes = createTest.Notes,
                TestResult = createTest.Result,
                CreatedByUserId = createTest.UserId
            };
        }
    }
}
