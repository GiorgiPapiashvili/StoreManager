using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Repository
{
    internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {
            
        }
    }
}