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
namespace DVLD.Business
{
    public class PersonService
    {
        public static async Task<bool> AddNewPersonAsync(Person newPerson)
        {
            newPerson.PersonId = await PersonData.AddNewPersonAsync(newPerson);
            return newPerson.PersonId != -1;
        }
        public static async Task<bool> UpdatePersonAsync(Person updatePerson)
        {
            return await PersonData.UpdatePersonAsync(updatePerson);
        }
        public static async Task<Person?> FindPersonAsync(int id)
        {
            Person? person = await PersonData.GetPersonByIDAsync(id);
            if (person != null)
                return person;
            return null;
        }

        public static async Task<Person?> FindPersonAsync(string nationalNo)
        {
            Person? person = await PersonData.GetPersonByNationalNoAsync(nationalNo);
            if (person != null)
                return person;
            return null;
        }

        public static async Task<List<PeopleInfo>> GetPeopleAsync()
        {
            return await PersonData.GetPeopleAsync();
        }

        public static async Task<bool> IsPersonExistAsync(int id)
        {
            return await PersonData.IsPersonExistAsync(id);
        }

        public static async Task<bool> IsPersonExistAsync(string nationalNo)
        {
            return await PersonData.IsPersonExistAsync(nationalNo);
        }

        public static async Task<bool> DeletePersonAsync(int id)
        {
            return await PersonData.DeletePersonAsync(id);
        }
    }
}
