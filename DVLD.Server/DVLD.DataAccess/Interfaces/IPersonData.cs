using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface IPersonData
{
    Task<Person?> GetPersonByIDAsync(int id, CancellationToken cancellationToken);
    Task<Person?> GetPersonByNationalNoAsync(string nationalNo, CancellationToken cancellationToken);
    Task<int> AddNewPersonAsync(Person newPerson, CancellationToken cancellationToken);
    Task<bool> UpdatePersonAsync(Person updatePerson, CancellationToken cancellationToken);
    Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken);
    Task<List<PeopleInfo>> GetPeopleAsync(CancellationToken cancellationToken);
    Task<bool> IsPersonExistAsync(int id, CancellationToken cancellationToken);
    Task<bool> IsPersonExistAsync(string nationalNo, CancellationToken cancellationToken);
}
