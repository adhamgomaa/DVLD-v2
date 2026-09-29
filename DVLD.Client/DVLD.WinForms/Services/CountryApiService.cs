using DVLD.DTOs.Countries;
using DVLD.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Services
{
    public class CountryApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<CountriesDto>?> GetAllCountriesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.Country.GetAll);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<CountriesDto>>();
        }

        public async Task<CountriesDto?> GetCountryByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Country.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<CountriesDto>();
        }
        public async Task<CountriesDto?> GetCountryByCountryNameAsync(string countryName)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Country.GetCountryName, countryName));
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<CountriesDto>();
        }
    }
}
