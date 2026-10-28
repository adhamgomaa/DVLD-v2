using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business.Implementations
{
    public sealed class TestService(ITestData testData) : ITestService
    {
        public async Task<bool> AddNewTestAsync(Test newTest, CancellationToken cancellationToken)
        {
            newTest.TestId = await testData.AddNewTestAsync(newTest, cancellationToken);
            return newTest.TestId != -1;
        }

        public async Task<bool> UpdateTestAsync(Test updateTest, CancellationToken cancellationToken)
        {
            return await testData.UpdateTestAsync(updateTest, cancellationToken);
        }

        public async Task<Test?> FindTestAsync(int appointmentId, CancellationToken cancellationToken)
        {
            Test? test = await testData.FindTest(appointmentId, cancellationToken);
            if (test != null)
                return test;
            return null;
        }

        public async Task<Test?> GetLastTestAsync(int localId, TestTypeEnum testType, CancellationToken cancellationToken)
        {
            Test? test = await testData.GetLastTestAsync(localId, testType, cancellationToken);
            if (test != null)
                return test;
            return null;
        }
    }
}
