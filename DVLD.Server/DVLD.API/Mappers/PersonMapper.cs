using DVLD.DTOs.People;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public static class PersonMapper
    {
        public static GetPersonDto ToGetDto(Person person)
        {
            return new GetPersonDto
            {
                PersonId = person.PersonId,
                NationalNo = person.NationalNo,
                FName = person.FName,
                SecName = person.SecName,
                ThName = person.ThName,
                LName = person.LName,
                Date = person.Date,
                Gendor = person.Gendor,
                Address = person.Address,
                Phone = person.Phone,
                Email = person.Email,
                NationaltyId = person.NationaltyId,
                ImagePath = person.ImagePath
            };      
        }

        public static PeopleDto ToPeopleDto(PeopleInfo person)
        {
            return new PeopleDto
            {
                PersonId = person.PersonId,
                NationalNo = person.NationalNo,
                FullName = person.FullName,
                Gendor = person.Gendor,
                Date = person.Date,
                Nationality = person.Nationality,
                Email = person.Email,
                Phone = person.Phone
            };
        }

        public static Person ToPerson(CreatePersonDto createPerson)
        {
            return new Person
            {
                NationalNo = createPerson.NationalNo,
                FName = createPerson.FName,
                SecName = createPerson.SecName,
                ThName = createPerson.ThName,
                LName = createPerson.LName,
                Date = createPerson.Date,
                Gendor = createPerson.Gendor,
                Address = createPerson.Address,
                Phone = createPerson.Phone,
                Email = createPerson.Email,
                NationaltyId = createPerson.NationaltyId,
                ImagePath = createPerson.ImagePath
            };
        }
    }
}
