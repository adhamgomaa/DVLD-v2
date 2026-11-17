using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;

namespace DVLD.Business.Implementations
{
    public sealed class TestService(ITestData testData) : ITestService
    {
        public async Task<bool> AddNewTestAsync(Test newTest, CancellationToken cancellationToken)
        {
            await testData.AddNewTestAsync(newTest, cancellationToken);
            return newTest.TestId != -1;
        }

        public Task<bool> UpdateTestAsync(Test updateTest, CancellationToken cancellationToken) =>
            testData.UpdateTestAsync(updateTest, cancellationToken);

        public Task<Test?> FindTestAsync(int appointmentId, CancellationToken cancellationToken) =>
            testData.FindTest(appointmentId, cancellationToken);

        public Task<Test?> GetLastTestAsync(int localId, TestTypeEnum testType, CancellationToken cancellationToken) =>
            testData.GetLastTestAsync(localId, testType, cancellationToken);
    }
}
