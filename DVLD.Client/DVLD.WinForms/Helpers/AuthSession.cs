namespace DVLD.WinForms.Helpers;

public static class AuthSession
{
    public static string? AccessToken { get; private set; }
    public static string? RefreshToken { get; private set; }
    public static void SetTokens(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public static void Clear()
    {
        AccessToken = null;
        RefreshToken = null;
    }
}
