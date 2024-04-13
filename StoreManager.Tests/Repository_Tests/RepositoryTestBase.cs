using Microsoft.Data.SqlClient;

namespace StoreManager.Tests.Repository_Tests;

public class RepositoryTestBase : IDisposable
{
    protected const string ConnectionString = "Server = .; Database = StoreManager.Database; Integrated Security = SSPI; TrustServerCertificate = true;";
    protected SqlConnection _connection;

    public RepositoryTestBase()
    {
        _connection = new SqlConnection(ConnectionString);
    }

    public virtual void Dispose()
    {
        _connection.Dispose();
    }
}
