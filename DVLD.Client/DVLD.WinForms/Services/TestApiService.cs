using DVLD.DTOs.Tests;
using DVLD.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DVLD.Shared.Enums;
using System.Net.Http.Json;

namespace DVLD.WinForms.Services
{
    public class TestApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;
        public async Task<TestDto?> GetTestByAppointmentIdAsync(int appointmentId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Test.GetId, appointmentId));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<TestDto>();
        }
        public async Task<TestDto?> GetLastTestAsync(int localId, TestTypeEnum testTypeId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Test.GetLastTest, localId, testTypeId));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<TestDto>();
        }
        public async Task<bool> AddTestAsync(CreateTestDto createTest)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.Test.Add, createTest);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateTestAsync(int id, UpdateTestDto updateTest)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.Test.Update, id), updateTest);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }
    }
}
