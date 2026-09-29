using DVLD.DTOs.TestAppointment;
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
    public class TestAppointmentApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<AppointmentDto>?> GetAllAppointmentsAsync(int localId, TestTypeEnum testTypeId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.TestAppointment.GetAll, localId, testTypeId));

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<AppointmentDto>>();
        }

        public async Task<GetAppointmentDto?> GetAppointmentByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.TestAppointment.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetAppointmentDto>();
        }
        public async Task<GetAppointmentDto?> GetLastAppointmentAsync(int localId, TestTypeEnum testTypeId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.TestAppointment.GetLastAppointment, localId, testTypeId));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetAppointmentDto>();
        }

        public async Task<int> GetTrailsAsync(int localId, TestTypeEnum testTypeId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.TestAppointment.GetTrails, localId, testTypeId));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return 0;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> IsAppointmentLockAsync(int localId, TestTypeEnum testTypeId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.TestAppointment.IsLock, localId, testTypeId));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<int> GetTestIdAsync(int appointmentId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.TestAppointment.GetTestId, appointmentId));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return -1;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> AddAppointmentAsync(CreateAppointmentDto createAppointment)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.TestAppointment.Add, createAppointment);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateAppointment)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.TestAppointment.Update, id), updateAppointment);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }
    }
}
