using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Repository;

internal sealed class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(string connectionString) : base(connectionString)
    {

    }
}
