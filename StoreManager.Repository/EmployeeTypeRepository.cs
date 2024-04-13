using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Repository
{
    internal sealed class EmployeeTypeRepository : RepositoryBase<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
