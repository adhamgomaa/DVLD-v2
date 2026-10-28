using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface ITestService
{
    Task<bool> AddNewTestAsync(Test newTest, CancellationToken cancellationToken);
    Task<bool> UpdateTestAsync(Test updateTest, CancellationToken cancellationToken);
    Task<Test?> FindTestAsync(int appointmentId, CancellationToken cancellationToken);
    Task<Test?> GetLastTestAsync(int localId, TestTypeEnum testType, CancellationToken cancellationToken);
}
