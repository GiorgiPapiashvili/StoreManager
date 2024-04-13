using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Repository;

internal sealed class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(string connectionString, SqlConnection? connection = null, SqlTransaction? transaction = null) : base(connectionString, connection, transaction)
    {

    }
}
