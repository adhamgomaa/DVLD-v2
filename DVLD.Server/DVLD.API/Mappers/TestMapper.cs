using DVLD.DTOs.Tests;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public class TestMapper
    {
        public static TestDto ToGetDto(Test test)
        {
            return new TestDto
            {
                TestId = test.TestId,
                AppointmentID = test.AppointmentID,
                Notes = test.Notes,
                Result = test.Result,
                UserId = test.UserId
            };
        }
        public static Test ToTest(CreateTestDto createTest)
        {
            return new Test
            {
                AppointmentID = createTest.AppointmentID,
                Notes = createTest.Notes,
                Result = createTest.Result,
                UserId = createTest.UserId
            };
        }
    }
}
