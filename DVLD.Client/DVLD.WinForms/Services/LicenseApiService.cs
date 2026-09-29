using DVLD.DTOs.Licenses;
using DVLD.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DVLD.Shared.Enums;
using DVLD.DTOs.Applications;

namespace DVLD.WinForms.Services
{
    public class LicenseApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<LicenseHistoryDto>?> GetAllLicensesAsync(int driverId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.License.GetAll, driverId));

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<LicenseHistoryDto>>();
        }

        public async Task<GetLicenseDto?> GetLicenseByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.License.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetLicenseDto>();
        }
        public async Task<int> GetLicenseIdByLocalIdAsync(int localId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.License.GetLocalId, localId));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return -1;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<int> GetLicenseIdByNationalNumberAsync(string nationalNo)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.License.GetNationalNumber, nationalNo));
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return -1;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> DeactiveLicenseAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.License.Deactivate, id));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<int> GetActiveLicenseIdAsync(int personId, int classId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.License.GetActiveLicense, personId, classId));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return -1;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<GetLicenseDto?> AddLicenseAsync(CreateLicenseDto createLicense)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.License.Add, createLicense);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetLicenseDto?>();
        }

        public async Task<bool> UpdateLicenseAsync(int id, UpdateLicenseDto updateLicense)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.License.Update, id), updateLicense);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public string GetIssueReasonText(IssueReasonEnum issueReason)
        {
            return issueReason switch
            {
                IssueReasonEnum.FirstTime => "First Time",
                IssueReasonEnum.Renew => "Renew",
                IssueReasonEnum.Damaged => "Replacement For Damaged",
                IssueReasonEnum.Lost => "Replacement For Lost",
                _ => "First Time",
            };
        }
    }
}
