using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;
namespace DVLD.Business.Implementations
{
    public sealed class PersonService(IPersonData personData) : IPersonService
    {
        public async Task<bool> AddNewPersonAsync(Person newPerson, CancellationToken cancellationToken)
        {
            await personData.AddNewPersonAsync(newPerson, cancellationToken);
            return newPerson.PersonId != -1;
        }
        public Task<bool> UpdatePersonAsync(Person updatePerson, CancellationToken cancellationToken) =>
            personData.UpdatePersonAsync(updatePerson, cancellationToken);
        public Task<Person?> FindPersonAsync(int id, CancellationToken cancellationToken) =>
            personData.GetPersonByIDAsync(id, cancellationToken);

        public Task<Person?> FindPersonAsync(string nationalNo, CancellationToken cancellationToken) =>
            personData.GetPersonByNationalNoAsync(nationalNo, cancellationToken);

        public Task<List<PersonInfo>> GetPeopleAsync(CancellationToken cancellationToken) =>
            personData.GetPeopleAsync(cancellationToken);

        public Task<bool> IsPersonExistAsync(int id, CancellationToken cancellationToken) =>
            personData.IsPersonExistAsync(id, cancellationToken);

        public Task<bool> IsPersonExistAsync(string nationalNo, CancellationToken cancellationToken) =>
            personData.IsPersonExistAsync(nationalNo, cancellationToken);

        public Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken) =>
            personData.DeletePersonAsync(id, cancellationToken);
    }
}
