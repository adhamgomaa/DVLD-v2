using DVLD.DataAccess.Data;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DVLD.DataAccess.Implementations
{
    public sealed class PersonData(AppDbContext context) : IPersonData
    {
        public async Task<Person?> GetPersonByIDAsync(int id, CancellationToken cancellationToken)
        {
            var person = await context.People.FindAsync([id], cancellationToken);
            return person;
        }
        
        public async Task<Person?> GetPersonByNationalNoAsync(string nationalNo, CancellationToken cancellationToken)
        {
            var person = await context.People.AsNoTracking().SingleOrDefaultAsync(p => p.NationalNo == nationalNo, cancellationToken);
            return person;
        }
        public async Task<int> AddNewPersonAsync(Person newPerson, CancellationToken cancellationToken)
        {
            context.People.Add(newPerson);
            await context.SaveChangesAsync(cancellationToken);
            return newPerson.PersonId;
        }
        public async Task<bool> UpdatePersonAsync(Person updatePerson, CancellationToken cancellationToken)
        {
            var person = await context.People.FindAsync([updatePerson.PersonId], cancellationToken);
            if(person is null)
                return false;
            person.Address = updatePerson.Address;
            person.BirthOfDate = updatePerson.BirthOfDate;
            person.Email = updatePerson.Email;
            person.FirstName = updatePerson.FirstName;
            person.Gendor = updatePerson.Gendor;
            person.ImagePath = updatePerson.ImagePath;
            person.LastName = updatePerson.LastName;
            person.SecondName = updatePerson.SecondName;
            person.ThirdName = updatePerson.ThirdName;
            person.NationalityCountryById = updatePerson.NationalityCountryById;
            person.NationalNo = updatePerson.NationalNo;
            person.Phone = updatePerson.Phone;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
        public async Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken)
        {
            var person = await context.People.FindAsync([id], cancellationToken);
            if (person is null)
                return false;
            context.People.Remove(person);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
        public async Task<List<PersonInfo>> GetPeopleAsync(CancellationToken cancellationToken)
        {
            var people = await context.People.AsNoTracking()
                            .Select(p => new PersonInfo
                            {
                                PersonId = p.PersonId,
                                NationalNo = p.NationalNo,
                                FullName = p.FirstName + " " + p.SecondName + " " + p.ThirdName + " " + p.LastName,
                                Gender = p.Gendor == 0 ? "Male" : "Female",
                                Date = p.BirthOfDate,
                                Nationality = p.NationalityCountryBy.CountryName,
                                Phone = p.Phone,
                                Email = p.Email
                            }).ToListAsync(cancellationToken);
            return people;
        }
        public async Task<bool> IsPersonExistAsync(int id, CancellationToken cancellationToken)
        {
            bool isExist = await context.People.AsNoTracking().AnyAsync(p => p.PersonId == id, cancellationToken);
            return isExist;
        }
        public async Task<bool> IsPersonExistAsync(string nationalNo, CancellationToken cancellationToken)
        {
            bool isExist = await context.People.AsNoTracking().AnyAsync(p => p.NationalNo == nationalNo, cancellationToken);
            return isExist;
        }
    }
}
