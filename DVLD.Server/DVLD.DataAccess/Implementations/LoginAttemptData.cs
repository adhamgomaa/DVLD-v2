using System.Data;
using DVLD.Shared.Entities;
using DVLD.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;

namespace DVLD.DataAccess.Implementations;

public sealed class LoginAttemptData(DatabaseSettings settings) : ILoginAttemptData
{
    public async Task AddAsync(
        int? userId,
        string attemptedUserName,
        bool succeeded,
        string? clientIpAddress,
        DateTime attemptedAtUtc,
        CancellationToken cancellationToken)
    {
        EnsureUtc(attemptedAtUtc);

        await using var connection = new SqlConnection(settings.ConnectionString);
        await using var command = new SqlCommand("SP_LoginAttempts_Add", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId is null ? DBNull.Value : userId.Value;
        command.Parameters.Add("@AttemptedUserName", SqlDbType.NVarChar, 256).Value = attemptedUserName;
        command.Parameters.Add("@Succeeded", SqlDbType.Bit).Value = succeeded;
        command.Parameters.Add("@ClientIpAddress", SqlDbType.VarChar, 45).Value =
            clientIpAddress is null ? DBNull.Value : clientIpAddress;
        command.Parameters.Add("@AttemptedAtUtc", SqlDbType.DateTime2).Value = attemptedAtUtc;

        await connection.OpenAsync(cancellationToken);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<LoginAttempt>> GetRecentAsync(
        int take,
        CancellationToken cancellationToken)
    {
        if (take is < 1 or > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(take), "The result count must be between 1 and 100.");
        }

        var attempts = new List<LoginAttempt>(take);
        await using var connection = new SqlConnection(settings.ConnectionString);
        await using var command = new SqlCommand("SP_LoginAttempts_GetRecent", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.Add("@Take", SqlDbType.Int).Value = take;

        await connection.OpenAsync(cancellationToken);
        await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess, cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            var ipOrdinal = reader.GetOrdinal("ClientIpAddress");
            attempts.Add(new LoginAttempt
            {
                LoginAttemptId = reader.GetInt64(reader.GetOrdinal("LoginAttemptId")),
                UserId = reader.IsDBNull(reader.GetOrdinal("UserId"))
                    ? null
                    : reader.GetInt32(reader.GetOrdinal("UserId")),
                AttemptedUserName = reader.GetString(reader.GetOrdinal("AttemptedUserName")),
                Succeeded = reader.GetBoolean(reader.GetOrdinal("Succeeded")),
                AttemptedAtUtc = DateTime.SpecifyKind(
                    reader.GetDateTime(reader.GetOrdinal("AttemptedAtUtc")),
                    DateTimeKind.Utc),
                ClientIpAddress = reader.IsDBNull(ipOrdinal) ? null : reader.GetString(ipOrdinal)
            });
        }

        return attempts;
    }

    private static void EnsureUtc(DateTime value)
    {
        if (value.Kind != DateTimeKind.Utc)
        {
            throw new ArgumentException("Login-attempt timestamps must be UTC.", nameof(value));
        }
    }
}
