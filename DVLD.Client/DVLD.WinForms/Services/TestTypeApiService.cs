using DVLD.DTOs.TestTypes;
using DVLD.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DVLD.Shared.Enums;

namespace DVLD.WinForms.Services
{
    public class TestTypeApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;
        public async Task<List<TestTypesDto>?> GetAllTypesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.TestType.GetAll);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<TestTypesDto>>();
        }

        public async Task<TestTypesDto?> GetTypeByIdAsync(TestTypeEnum id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.TestType.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<TestTypesDto>();
        }
        public async Task<bool> UpdateTypeAsync(TestTypeEnum id, UpdateTestTypesDto updateUser)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.TestType.Update, id), updateUser);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }
    }
}
