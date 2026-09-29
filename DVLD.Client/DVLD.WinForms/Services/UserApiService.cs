using DVLD.DTOs.Users;
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
    public class UserApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<LoginUserDto?> LoginAsync(LoginRequestDto loginRequest)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.User.Login, loginRequest);
            
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<LoginUserDto>();
        }

        public async Task<List<UserInfoDto>?> GetAllUserAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.User.GetAll);
            
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<UserInfoDto>>();
        }

        public async Task<GetUserDto?> GetUserInfoByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.User.GetInfo, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetUserDto>();
        }
        
        public async Task<LoginUserDto?> GetUserByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.User.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<LoginUserDto>();
        }
        public async Task<GetUserDto?> GetUserByUsernameAsync(string username)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.User.GetUsername, username));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetUserDto>();
        }

        public async Task<bool> IsUserExistAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.User.IsExist, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<bool>();
        }
        
        public async Task<bool> IsUserExistByUsernameAsync(string username)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.User.IsExistByUsername, username));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<bool>();
        }
        
        public async Task<bool> IsUserExistByPersonIdAsync(int personId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.User.IsExistByPersonId, personId));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> AddUserAsync(CreateUserDto createUser)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.User.Add, createUser);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto updateUser)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.User.Update, id), updateUser);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(string.Format(ApiRoutes.User.Delete, id));
            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            return response.IsSuccessStatusCode;
        }
    }
}
