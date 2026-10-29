using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface ITestData
{
    Task<int> AddNewTestAsync(Test newTest, CancellationToken cancellationToken);
    Task<bool> UpdateTestAsync(Test updateTest, CancellationToken cancellationToken);
    Task<Test?> FindTest(int appointmentId, CancellationToken cancellationToken);
    Task<Test?> GetLastTestAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken);
}
