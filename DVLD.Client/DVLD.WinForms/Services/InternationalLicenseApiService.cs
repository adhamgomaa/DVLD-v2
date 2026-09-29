using DVLD.DTOs.InternationalLicense;
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
    public class InternationalLicenseApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<InternationalLicenseDto>?> GetAllInternationalLicenseAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.InternationalLicense.GetAll);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<InternationalLicenseDto>>();
        }
        public async Task<List<InternationalHistoryDto>?> GetAllInternationalLicenseHistoryAsync(int driverId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.InternationalLicense.GetHistory, driverId));

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<InternationalHistoryDto>>();
        }

        public async Task<InternationalLicenseDto?> GetInternationalLicenseByIdAsync(int InternationalId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.InternationalLicense.GetId, InternationalId));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<InternationalLicenseDto>();
        }
        public async Task<InternationalLicenseDto?> GetInternationalLicenseIdByLocalIdAsync(int localId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.InternationalLicense.GetLocalId, localId));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<InternationalLicenseDto>();
        }

        public async Task<int> GetActiveLicenseIdAsync(int driverId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.InternationalLicense.GetActiveLicense, driverId));
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return -1;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<InternationalLicenseDto?> AddInternationalLicenseAsync(CreateInternationalLicenseDto createInternationalLicense)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.InternationalLicense.Add, createInternationalLicense);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<InternationalLicenseDto>();
        }
    }
}
