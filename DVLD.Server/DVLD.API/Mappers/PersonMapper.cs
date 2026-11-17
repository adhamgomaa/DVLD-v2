using DVLD.DTOs.People;
using DVLD.Shared.Models;

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
                FirstName = person.FirstName,
                SecondName = person.SecondName,
                ThirdName = person.ThirdName,
                LastName = person.LastName,
                Date = person.BirthOfDate,
                Gender = person.Gendor == 0 ? "Male" : "Female",
                Address = person.Address,
                Phone = person.Phone,
                Email = person.Email,
                NationalityId = person.NationalityCountryById,
                ImagePath = person.ImagePath
            };      
        }

        public static PeopleDto ToPeopleDto(PersonInfo person)
        {
            return new PeopleDto
            {
                PersonId = person.PersonId,
                NationalNo = person.NationalNo,
                FullName = person.FullName,
                Gender = person.Gender,
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
                FirstName = createPerson.FirstName,
                SecondName = createPerson.SecondName,
                ThirdName = createPerson.ThirdName,
                LastName = createPerson.LName,
                BirthOfDate = createPerson.Date,
                Gendor = createPerson.Gender,
                Address = createPerson.Address,
                Phone = createPerson.Phone,
                Email = createPerson.Email,
                NationalityCountryById = createPerson.NationalityId,
                ImagePath = createPerson.ImagePath
            };
        }
    }
}
