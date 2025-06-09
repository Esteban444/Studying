namespace CleanArchitecture.Infrastructure.Data;

using CleanArchitecture.Application.Abstractions.Data;
using Npgsql;
using System.Data;

public class SQLConnectionFactory : ISqlConnectionFactory
{
    private readonly string connectionString;

    public SQLConnectionFactory( string connectionString )
    {
        this.connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection( connectionString );
        connection.Open();

        return connection;
    }
}
