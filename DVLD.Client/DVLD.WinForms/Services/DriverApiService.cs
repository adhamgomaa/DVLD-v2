using DVLD.DTOs.Applications;
using DVLD.DTOs.Drivers;
using DVLD.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Services
{
    public class DriverApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<DriverDto>?> GetAllDriversAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.Driver.GetAll);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<DriverDto>>();
        }
        public async Task<GetDriverDto?> GetDriverByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Driver.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetDriverDto>();
        }
        public async Task<GetDriverDto?> GetDriverIdByPersonIdAsync(int personId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Driver.GetPersonId, personId));
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetDriverDto>();
        }

        public async Task<bool> IsPersonDriverAsync(int personId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Driver.IsPersonDriver, personId));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<GetDriverDto?> AddDriverAsync(CreateDriverDto createDriver)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.Driver.Add, createDriver);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetDriverDto>();
        }
    }
}
