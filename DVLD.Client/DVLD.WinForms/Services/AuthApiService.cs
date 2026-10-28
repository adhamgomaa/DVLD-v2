using DVLD.DTOs.Auth;
using DVLD.WinForms.Helpers;
using System.Net;
using System.Net.Http.Json;

namespace DVLD.WinForms.Services
{
    public sealed class AuthApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;
        private readonly HttpClient _authHttpClient = ApiClient.AuthClient;
        private static readonly SemaphoreSlim RefreshGate = new(1, 1);

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto loginRequest, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
                ApiRoutes.Auth.Login,
                loginRequest,
                cancellationToken);

            if (response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.Unauthorized)
                return null;

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                string retryAfter = response.Headers.RetryAfter?.Delta is TimeSpan delay
                    ? $" Try again in {Math.Ceiling(delay.TotalSeconds)} seconds."
                    : string.Empty;
                throw new HttpRequestException(
                    $"Too many login attempts.{retryAfter}",
                    null,
                    response.StatusCode);
            }

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(await response.Content.ReadAsStringAsync(cancellationToken), null, response.StatusCode);

            LoginResponseDto? tokens =
                await response.Content.ReadFromJsonAsync<LoginResponseDto>(cancellationToken: cancellationToken) ?? throw new InvalidOperationException("The authentication response did not contain tokens.");
            if (string.IsNullOrWhiteSpace(tokens.AccessToken) ||
                string.IsNullOrWhiteSpace(tokens.RefreshToken))
                throw new InvalidOperationException("The authentication response contained invalid tokens.");

            AuthSession.SetTokens(tokens.AccessToken, tokens.RefreshToken);
            return tokens;
        }

        public async Task<bool> RefreshAsync(
            string? expiredAccessToken,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(AuthSession.RefreshToken))
                return false;

            await RefreshGate.WaitAsync(cancellationToken);
            try
            {
                if (!string.Equals(AuthSession.AccessToken, expiredAccessToken, StringComparison.Ordinal))
                    return true;

                HttpResponseMessage response = await _authHttpClient.PostAsJsonAsync(
                    ApiRoutes.Auth.Refresh,
                    new RefreshTokenRequestDto { RefreshToken = AuthSession.RefreshToken },
                    cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    AuthSession.Clear();
                    return false;
                }

                LoginResponseDto? tokens =
                    await response.Content.ReadFromJsonAsync<LoginResponseDto>(cancellationToken);
                if (tokens is null ||
                    string.IsNullOrWhiteSpace(tokens.AccessToken) ||
                    string.IsNullOrWhiteSpace(tokens.RefreshToken))
                {
                    AuthSession.Clear();
                    return false;
                }

                AuthSession.SetTokens(tokens.AccessToken, tokens.RefreshToken);
                return true;
            }
            finally
            {
                RefreshGate.Release();
            }
        }

        public async Task LogoutAsync(CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(AuthSession.RefreshToken))
            {
                AuthSession.Clear();
                return;
            }

            HttpResponseMessage response = await _authHttpClient.PostAsJsonAsync(
                ApiRoutes.Auth.Logout,
                new RefreshTokenRequestDto { RefreshToken = AuthSession.RefreshToken },
                cancellationToken);

            AuthSession.Clear();
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }
    }
}
