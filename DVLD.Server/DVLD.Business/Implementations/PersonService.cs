using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
namespace DVLD.Business.Implementations
{
    public sealed class PersonService(IPersonData personData) : IPersonService
    {
        public async Task<bool> AddNewPersonAsync(Person newPerson, CancellationToken cancellationToken)
        {
            newPerson.PersonId = await personData.AddNewPersonAsync(newPerson, cancellationToken);
            return newPerson.PersonId != -1;
        }
        public async Task<bool> UpdatePersonAsync(Person updatePerson, CancellationToken cancellationToken)
        {
            return await personData.UpdatePersonAsync(updatePerson, cancellationToken);
        }
        public async Task<Person?> FindPersonAsync(int id, CancellationToken cancellationToken)
        {
            Person? person = await personData.GetPersonByIDAsync(id, cancellationToken);
            if (person != null)
                return person;
            return null;
        }

        public async Task<Person?> FindPersonAsync(string nationalNo, CancellationToken cancellationToken)
        {
            Person? person = await personData.GetPersonByNationalNoAsync(nationalNo, cancellationToken);
            if (person != null)
                return person;
            return null;
        }

        public async Task<List<PeopleInfo>> GetPeopleAsync(CancellationToken cancellationToken)
        {
            return await personData.GetPeopleAsync(cancellationToken);
        }

        public async Task<bool> IsPersonExistAsync(int id, CancellationToken cancellationToken)
        {
            return await personData.IsPersonExistAsync(id, cancellationToken);
        }

        public async Task<bool> IsPersonExistAsync(string nationalNo, CancellationToken cancellationToken)
        {
            return await personData.IsPersonExistAsync(nationalNo, cancellationToken);
        }

        public async Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken)
        {
            return await personData.DeletePersonAsync(id, cancellationToken);
        }
    }
}
