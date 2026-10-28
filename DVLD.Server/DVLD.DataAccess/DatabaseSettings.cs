namespace DVLD.DataAccess;

public sealed class DatabaseSettings(string connectionString)
{
    public string ConnectionString { get; } = string.IsNullOrWhiteSpace(connectionString)
        ? throw new ArgumentException("A database connection string is required.", nameof(connectionString))
        : connectionString;
}
