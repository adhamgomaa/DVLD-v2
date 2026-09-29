using DVLD.DTOs.LocalLicense;
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
using DVLD.DTOs.Drivers;
using DVLD.DTOs.Licenses;
using DVLD.DTOs.LicenseClass;

namespace DVLD.WinForms.Services
{
    public class LocalLicenseApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<LocalLicenseDto>?> GetAllLocalLicenseAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.LocalLicense.GetAll);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<LocalLicenseDto>>();
        }

        public async Task<GetLocalLicenseDto?> GetLocalLicenseByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.LocalLicense.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetLocalLicenseDto>();
        }
        public async Task<bool> CancelLocalLicenseAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.LocalLicense.Cancel, id));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> CheckPersonHasSameClassAsync(int personId, int classId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.LocalLicense.CheckSameClass, personId, classId));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> GetActiveLicenseAsync(GetLocalLicenseDto localLicense)
        {
            GetAppDto app = await new ApplicationApiService().GetAppByIdAsync(localLicense.AppId) ?? new GetAppDto();
            bool result = await new LicenseApiService().GetActiveLicenseIdAsync(app.PersonId, localLicense.ClassId) != -1;
            return result;
        }

        public async Task<bool> IsPassedAllTestsAsync(int localId)
        {
            bool result = await GetPassedTestCountAsync(localId) == 3;
            return result;
        }

        public async Task<byte> GetPassedTestCountAsync(int localId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.LocalLicense.GetPassedTestCount, localId));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return 0;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<byte>();
        }
        public async Task<byte> GetTotalTrailsPerTestAsync(int localId, TestTypeEnum testTypeId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.LocalLicense.GetTotalTrailsTest, localId, testTypeId));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return 0;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<byte>();
        }
        public async Task<bool> DoseAttendTestTypeAsync(int localId, TestTypeEnum testTypeId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.LocalLicense.DoseAttendTest, localId, testTypeId));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> DosePassTestTypeAsync(int localId, TestTypeEnum testTypeId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.LocalLicense.DosePassTest, localId, testTypeId));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> IsThereAnActiveTestAsync(int localId, TestTypeEnum testTypeId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.LocalLicense.IsAnActiveTest, localId, testTypeId));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> AddLocalLicenseAsync(CreateLocalLicenseDto createLocalLicense)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.LocalLicense.Add, createLocalLicense);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateLocalLicenseAsync(int id, UpdateLocalLicenseDto updateLocalLicense)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.LocalLicense.Update, id), updateLocalLicense);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteLocalLicenseAsync(int localId, int appId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(string.Format(ApiRoutes.LocalLicense.Delete, localId, appId));
            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            return response.IsSuccessStatusCode;
        }
    }
}
