using DVLD.DTOs.DetainLicense;
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
    public class DetainLicenseApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<DetainLicenseDto>?> GetAllDetainLicensesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.DetainLicense.GetAll);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<DetainLicenseDto>>();
        }
        public async Task<GetDetainDto?> GetDetainLicenseByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.DetainLicense.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetDetainDto>();
        }

        public async Task<bool> IsLicenseDetainedAsync(int licenseId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.DetainLicense.IsLicenseDetained, licenseId));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<GetDetainDto?> AddDetainLicenseAsync(CreateDetainLicenseDto createDetainLicense)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.DetainLicense.Add, createDetainLicense);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetDetainDto>();
        }

        public async Task<bool> UpdateDetainLicenseAsync(int id, UpdateDetainLicenseDto updateDetainLicense)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.DetainLicense.Update, id), updateDetainLicense);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }
        public async Task<ReleaseLicenseDto?> ReleaseLicenseAsync(int id, ReleaseLicenseDto releaseLicense)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.DetainLicense.ReleaseLicense, id), releaseLicense);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<ReleaseLicenseDto>();
        }
    }
}
