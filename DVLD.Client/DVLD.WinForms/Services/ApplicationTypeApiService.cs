using DVLD.DTOs.ApplicationTypes;
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
    public class ApplicationTypeApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<TypesDto>?> GetAllTypesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.ApplicationType.GetAll);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<TypesDto>>();
        }

        public async Task<TypesDto?> GetTypeByIdAsync(AppTypeEnum id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.ApplicationType.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<TypesDto>();
        }
        public async Task<TypesDto?> GetTypeByTitleAsync(string title)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.ApplicationType.GetTitle, title));
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<TypesDto>();
        }

        public async Task<bool> UpdateAppTypeAsync(AppTypeEnum id, UpdateAppTypeDto updateAppType)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.ApplicationType.Update, id), updateAppType);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }
    }
}
