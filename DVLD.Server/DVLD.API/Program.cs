using DVLD.DataAccess.Interfaces;
using DVLD.DataAccess.Implementations;
using DVLD.Business.Interfaces;
using DVLD.Business.Implementations;
using DVLD.API.Interfaces;
using DVLD.API.Implementations;
using DVLD.DataAccess;
using DVLD.API.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Threading.RateLimiting;


var builder = WebApplication.CreateBuilder(args);
builder.Host.UseDefaultServiceProvider((_, options) =>
{
    options.ValidateScopes = true;
    options.ValidateOnBuild = true;
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("ConnectionStrings:DefaultConnection is not configured.");

string? jwtSigningKey = builder.Configuration["Jwt:SigningKey"];
if (string.IsNullOrWhiteSpace(jwtSigningKey) || Encoding.UTF8.GetByteCount(jwtSigningKey) < 32)
{
    throw new InvalidOperationException(
        "JWT signing key is missing or too short. Configure Jwt:SigningKey with a random secret of at least 32 UTF-8 bytes, for example using the Jwt__SigningKey environment variable.");
}

var jwtSettings = new JwtTokenSettings(
    Issuer: builder.Configuration["Jwt:Issuer"] ?? "DVLD.API",
    Audience: builder.Configuration["Jwt:Audience"] ?? "DVLD.Client",
    SigningKey: jwtSigningKey,
    AccessTokenMinutes: builder.Configuration.GetValue<int?>("Jwt:AccessTokenMinutes") ?? 30,
    RefreshTokenDays: builder.Configuration.GetValue<int?>("Jwt:RefreshTokenDays") ?? 7);

if (jwtSettings.AccessTokenMinutes <= 0 || jwtSettings.RefreshTokenDays <= 0)
{
    throw new InvalidOperationException("Jwt:AccessTokenMinutes and Jwt:RefreshTokenDays must be greater than zero.");
}

builder.Services.AddSingleton(jwtSettings);
builder.Services.AddSingleton(new DatabaseSettings(connectionString));

// Data access implementations
builder.Services.AddScoped<IApplicationData, ApplicationData>();
builder.Services.AddScoped<IApplicationTypeData, ApplicationTypeData>();
builder.Services.AddScoped<ICountryData, CountryData>();
builder.Services.AddScoped<IDetainLicenseData, DetainLicenseData>();
builder.Services.AddScoped<IDriverData, DriverData>();
builder.Services.AddScoped<IInternationalLicenseData, InternationalLicenseData>();
builder.Services.AddScoped<ILicenseClassData, LicenseClassData>();
builder.Services.AddScoped<ILicenseData, LicenseData>();
builder.Services.AddScoped<ILocalDrivingLicenseData, LocalDrivingLicenseData>();
builder.Services.AddScoped<IPersonData, PersonData>();
builder.Services.AddScoped<IRefreshTokenData, RefreshTokenData>();
builder.Services.AddScoped<ITestAppointmentData, TestAppointmentData>();
builder.Services.AddScoped<ITestData, TestData>();
builder.Services.AddScoped<ITestTypeData, TestTypeData>();
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<ILoginAttemptData, LoginAttemptData>();

// Business implementations
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IApplicationTypeService, ApplicationTypeService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IDetainLicenseService, DetainLicenseService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IInternationalLicenseService, InternationalLicenseService>();
builder.Services.AddScoped<ILicenseClassService, LicenseClassService>();
builder.Services.AddScoped<ILicenseService, LicenseService>();
builder.Services.AddScoped<ILocalDrivingLicenseService, LocalDrivingLicenseService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();
builder.Services.AddScoped<ITestAppointmentService, TestAppointmentService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<ITestTypeService, TestTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoginAttemptService, LoginAttemptService>();
builder.Services.AddSingleton<ICryptographyService, CryptographyService>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            RequireExpirationTime = true,
            RequireSignedTokens = true,
            ClockSkew = TimeSpan.Zero,
            ValidAlgorithms = [SecurityAlgorithms.HmacSha256],
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SigningKey))
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddProblemDetails();

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.OnRejected = static (context, cancellationToken) =>
    {
        if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
        {
            context.HttpContext.Response.Headers.RetryAfter =
                Math.Max(1, (long)Math.Ceiling(retryAfter.TotalSeconds)).ToString();
        }

        return ValueTask.CompletedTask;
    };

    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        CreateFixedWindowLimiter(GetClientKey(httpContext), 120, TimeSpan.FromMinutes(1)));

    options.AddPolicy(RateLimitPolicies.Login, httpContext =>
        CreateFixedWindowLimiter(GetClientKey(httpContext), 5, TimeSpan.FromMinutes(1)));

    options.AddPolicy(RateLimitPolicies.Refresh, httpContext =>
        CreateFixedWindowLimiter(GetClientKey(httpContext), 10, TimeSpan.FromMinutes(1)));

    options.AddPolicy(RateLimitPolicies.Logout, httpContext =>
        CreateFixedWindowLimiter(GetClientKey(httpContext), 30, TimeSpan.FromMinutes(1)));
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the access token from POST /api/Auth/login.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    options.OperationFilter<AuthorizeOperationFilter>();
});

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>() ?? [];

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseRouting();
app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static string GetClientKey(HttpContext httpContext) =>
    httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown-client";

static RateLimitPartition<string> CreateFixedWindowLimiter(
    string partitionKey,
    int permitLimit,
    TimeSpan window) =>
    RateLimitPartition.GetFixedWindowLimiter(
        partitionKey,
        _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = permitLimit,
            Window = window,
            QueueLimit = 0,
            AutoReplenishment = true
        });
