using System.Data;

namespace StoreManager.Service.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICityRepository CityRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeTypeRepository EmployeeTypeRepository { get; }
        IProductRepository ProductRepository { get; }
        IPurchaseRepository PurchaseRepository { get; }
        IPurchaseDetailsRepository PurchaseDetailsRepository { get; }
        ISaleRepository SaleRepository { get; }
        ISaleDetailRepository SaleDetailRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IUserRepository UserRepository { get; }

        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
        IDbConnection GetConnection();
        new void Dispose();
    }
}

