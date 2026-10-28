using System.Net.Http.Headers;
using DVLD.WinForms.Services;

namespace DVLD.WinForms.Helpers;

public sealed class BearerTokenHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(AuthSession.AccessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                AuthSession.AccessToken);
        }

        string? accessToken = AuthSession.AccessToken;
        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
        if (response.StatusCode != System.Net.HttpStatusCode.Unauthorized ||
            IsAuthenticationRequest(request.RequestUri))
            return response;

        response.Dispose();
        if (!await new AuthApiService().RefreshAsync(accessToken, cancellationToken))
            return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

        using HttpRequestMessage retry = await CloneRequestAsync(request, cancellationToken);
        retry.Headers.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            AuthSession.AccessToken);
        return await base.SendAsync(retry, cancellationToken);
    }

    private static bool IsAuthenticationRequest(Uri? requestUri)
    {
        string path = requestUri?.AbsolutePath ?? string.Empty;
        return path.EndsWith("/Auth/login", StringComparison.OrdinalIgnoreCase) ||
               path.EndsWith("/Auth/refresh", StringComparison.OrdinalIgnoreCase) ||
               path.EndsWith("/Auth/logout", StringComparison.OrdinalIgnoreCase);
    }

    private static async Task<HttpRequestMessage> CloneRequestAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        HttpRequestMessage clone = new(request.Method, request.RequestUri);
        foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
            clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

        if (request.Content is not null)
        {
            clone.Content = new ByteArrayContent(
                await request.Content.ReadAsByteArrayAsync(cancellationToken));
            foreach (KeyValuePair<string, IEnumerable<string>> header in request.Content!.Headers)
                clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        return clone;
    }
}
