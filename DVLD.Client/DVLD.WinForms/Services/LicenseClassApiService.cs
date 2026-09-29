using DVLD.DTOs.LicenseClass;
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
    public class LicenseClassApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<LicenseClassDto>?> GetAllLicenseClassAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.LicenseClass.GetAll);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<LicenseClassDto>>();
        }

        public async Task<LicenseClassDto?> GetLicenseClassByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.LicenseClass.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<LicenseClassDto>();
        }
        public async Task<LicenseClassDto?> GetLicenseClassByClassNameAsync(string classname)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.LicenseClass.GetClassName, classname));
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<LicenseClassDto>();
        }
    }
}
