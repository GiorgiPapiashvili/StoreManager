using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Repository
{
    internal sealed class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
