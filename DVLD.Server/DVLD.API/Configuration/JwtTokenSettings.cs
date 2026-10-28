using System;

namespace DVLD.API.Configuration;

public sealed record JwtTokenSettings
(
    string Issuer,
    string Audience,
    string SigningKey,
    int AccessTokenMinutes,
    int RefreshTokenDays
);
