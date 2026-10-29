using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface IPersonService
{
    Task<bool> AddNewPersonAsync(Person newPerson, CancellationToken cancellationToken);
    Task<bool> UpdatePersonAsync(Person updatePerson, CancellationToken cancellationToken);
    Task<Person?> FindPersonAsync(int id, CancellationToken cancellationToken);
    Task<Person?> FindPersonAsync(string nationalNo, CancellationToken cancellationToken);
    Task<List<PeopleInfo>> GetPeopleAsync(CancellationToken cancellationToken);
    Task<bool> IsPersonExistAsync(int id, CancellationToken cancellationToken);
    Task<bool> IsPersonExistAsync(string nationalNo, CancellationToken cancellationToken);
    Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken);
}
