using DVLD.DataAccess;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class TestService
    {
        public static async Task<bool> AddNewTestAsync(Test newTest)
        {
            newTest.TestId = await TestData.AddNewTestAsync(newTest);
            return newTest.TestId != -1;
        }

        public static async Task<bool> UpdateTestAsync(Test updateTest)
        {
            return await TestData.UpdateTestAsync(updateTest);
        }

        public static async Task<Test?> FindTestAsync(int appointmentId)
        {
            Test? test = await TestData.FindTest(appointmentId);
            if (test != null)
                return test;
            return null;
        }

        public static async Task<Test?> GetLastTestAsync(int localId, TestTypeEnum testType)
        {
            Test? test = await TestData.GetLastTestAsync(localId, testType);
            if (test != null)
                return test;
            return null;
        }
    }
}
