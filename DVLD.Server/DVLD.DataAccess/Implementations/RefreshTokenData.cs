using System.Data;
using DVLD.Shared.Entities;
using DVLD.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;

namespace DVLD.DataAccess.Implementations;

public sealed class RefreshTokenData(DatabaseSettings databaseSettings) : IRefreshTokenData
    {
    public async Task<long> AddAsync(
        int userId,
        string tokenHash,
        DateTime expiresAt,
        Guid tokenFamilyId,
        CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(databaseSettings.ConnectionString);
        await using var command = new SqlCommand("SP_RefreshTokens_AddNew", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
        command.Parameters.Add("@TokenHash", SqlDbType.Char, 64).Value = tokenHash;
        command.Parameters.Add("@ExpiresAt", SqlDbType.DateTime2).Value = expiresAt;
        command.Parameters.Add("@TokenFamilyId", SqlDbType.UniqueIdentifier).Value = tokenFamilyId;
        var refreshTokenId = command.Parameters.Add("@RefreshTokenId", SqlDbType.BigInt);
        refreshTokenId.Direction = ParameterDirection.Output;

        await connection.OpenAsync(cancellationToken);
        await command.ExecuteNonQueryAsync(cancellationToken);

        return refreshTokenId.Value is long id
            ? id
            : throw new InvalidOperationException("The add-refresh-token procedure did not return a refresh token ID.");
    }

    public async Task<RefreshToken?> GetByHashAsync(
        string tokenHash,
        CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(databaseSettings.ConnectionString);
        await using var command = new SqlCommand("SP_RefreshTokens_GetByHash", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.Add("@TokenHash", SqlDbType.Char, 64).Value = tokenHash;

        await connection.OpenAsync(cancellationToken);
        await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow, cancellationToken);
        if (!await reader.ReadAsync(cancellationToken))
        {
            return null;
        }

        return new RefreshToken
        {
            RefreshTokenId = reader.GetInt64(reader.GetOrdinal("RefreshTokenId")),
            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
            TokenHash = reader.GetString(reader.GetOrdinal("TokenHash")),
            CreatedAt = ReadUtcDateTime(reader, "CreatedAt"),
            ExpiresAt = ReadUtcDateTime(reader, "ExpiresAt"),
            RevokedAt = reader.GetValue(reader.GetOrdinal("RevokedAt")) == DBNull.Value ? null : ReadUtcDateTime(reader, "RevokedAt"),
            ReplacedByTokenId = reader.GetValue(reader.GetOrdinal("ReplacedByTokenId")) is long replacedByTokenId ? replacedByTokenId : null,
            TokenFamilyId = reader.GetGuid(reader.GetOrdinal("TokenFamilyId"))
        };
    }

    public async Task RevokeAsync(string tokenHash, CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(databaseSettings.ConnectionString);
        await using var command = new SqlCommand("SP_RefreshTokens_Revoke", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.Add("@TokenHash", SqlDbType.Char, 64).Value = tokenHash;

        await connection.OpenAsync(cancellationToken);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public async Task RevokeFamilyAsync(
        int userId,
        Guid tokenFamilyId,
        CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(databaseSettings.ConnectionString);
        await using var command = new SqlCommand("SP_RefreshTokens_RevokeFamily", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
        command.Parameters.Add("@TokenFamilyId", SqlDbType.UniqueIdentifier).Value = tokenFamilyId;

        await connection.OpenAsync(cancellationToken);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public async Task<long> RotateAsync(
        long oldRefreshTokenId,
        string oldTokenHash,
        string newTokenHash,
        DateTime newExpiresAt,
        CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(databaseSettings.ConnectionString);
        await using var command = new SqlCommand("SP_RefreshTokens_Rotate", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.Add("@OldRefreshTokenId", SqlDbType.BigInt).Value = oldRefreshTokenId;
        command.Parameters.Add("@OldTokenHash", SqlDbType.Char, 64).Value = oldTokenHash;
        command.Parameters.Add("@NewTokenHash", SqlDbType.Char, 64).Value = newTokenHash;
        command.Parameters.Add("@NewExpiresAtUtc", SqlDbType.DateTime2).Value = newExpiresAt;
        var newRefreshTokenId = command.Parameters.Add("@NewRefreshTokenId", SqlDbType.BigInt);
        newRefreshTokenId.Direction = ParameterDirection.Output;

        await connection.OpenAsync(cancellationToken);
        await command.ExecuteNonQueryAsync(cancellationToken);

        return newRefreshTokenId.Value is long id ? id : 0;
    }

    private static DateTime ReadUtcDateTime(SqlDataReader reader, string columnName)
    {
        var value = reader.GetValue(reader.GetOrdinal(columnName));
        return value switch
        {
            DateTime dateTime => DateTime.SpecifyKind(dateTime, DateTimeKind.Utc),
            _ => throw new InvalidCastException($"Column '{columnName}' must contain a SQL date/time value.")
        };
    }
}
