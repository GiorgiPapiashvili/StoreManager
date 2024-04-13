using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Repository
{
    internal sealed class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
