using DVLD.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DVLD.DTOs.People;

namespace DVLD.WinForms.Services
{
    public class PersonApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<PeopleDto>?> GetAllPeopleAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.Person.GetAll);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<PeopleDto>>();
        }

        public async Task<GetPersonDto?> GetPersonByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Person.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetPersonDto>();
        }
        public async Task<GetPersonDto?> GetPersonByNationalNumberAsync(string nationalNo)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Person.GetNationalNumber, nationalNo));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetPersonDto>();
        }

        public async Task<bool> IsPersonExistAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Person.IsExist, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> IsPersonExistByNationalNumberAsync(string nationalNo)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Person.IsExistByNational, nationalNo));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> AddPersonAsync(CreatePersonDto createPerson)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.Person.Add, createPerson);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePersonAsync(int id, UpdatePersonDto updatePerson)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.Person.Update, id), updatePerson);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(string.Format(ApiRoutes.Person.Delete, id));
            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            return response.IsSuccessStatusCode;
        }
    }
}
