using Microsoft.Data.SqlClient;
using StoreManager.Service.Interfaces.Repositories;
using System.Data;

namespace StoreManager.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection? _connection;
        private SqlTransaction? _transaction;
        private bool _isDisposed = false;

        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ICountryRepository> _countryRepository;
        private readonly Lazy<ICityRepository> _cityRepository;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IEmployeeTypeRepository> _employeeTypeRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IPurchaseRepository> _purchaseRepository;
        private readonly Lazy<IPurchaseDetailsRepository> _purchaseDetailsRepository;
        private readonly Lazy<ISaleRepository> _saleRepository;
        private readonly Lazy<ISaleDetailRepository> _saleDetailRepository;
        private readonly Lazy<ISupplierRepository> _supplierRepository;
        private readonly Lazy<IUserRepository> _userRepository;

        public UnitOfWork(string connectionString)
        {

            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(connectionString, (SqlConnection)GetConnection(), _transaction));
            _countryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(connectionString));
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(connectionString));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(connectionString));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(connectionString));
            _employeeTypeRepository = new Lazy<IEmployeeTypeRepository>(() => new EmployeeTypeRepository(connectionString));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(connectionString));
            _purchaseRepository = new Lazy<IPurchaseRepository>(() => new PurchaseRepository(connectionString));
            _purchaseDetailsRepository = new Lazy<IPurchaseDetailsRepository>(() => new PurchaseDetailsRepository(connectionString));
            _saleRepository = new Lazy<ISaleRepository>(() => new SaleRepository(connectionString));
            _saleDetailRepository = new Lazy<ISaleDetailRepository>(() => new SaleDetailRepository(connectionString));
            _supplierRepository = new Lazy<ISupplierRepository>(() => new SupplierRepository(connectionString));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(connectionString));
        }

        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Transaction already started!");
            }

            SqlConnection connection = (SqlConnection)GetConnection();
            _transaction = connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction is not started!");
            }
            _transaction.Commit();
            _transaction = null;
        }

        public void RollBackTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction is not started!");
            }
            _transaction.Rollback();
            _transaction = null;
        }

        public IDbConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }

            return _connection;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public ICountryRepository CountryRepository => _countryRepository.Value;

        public ICityRepository CityRepository => _cityRepository.Value;

        public ICustomerRepository CustomerRepository => _customerRepository.Value;

        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public IEmployeeTypeRepository EmployeeTypeRepository => _employeeTypeRepository.Value;

        public IProductRepository ProductRepository => _productRepository.Value;

        public IPurchaseRepository PurchaseRepository => _purchaseRepository.Value;

        public IPurchaseDetailsRepository PurchaseDetailsRepository => _purchaseDetailsRepository.Value;

        public ISaleRepository SaleRepository => _saleRepository.Value;

        public ISaleDetailRepository SaleDetailRepository => _saleDetailRepository.Value;

        public ISupplierRepository SupplierRepository => _supplierRepository.Value;

        public IUserRepository UserRepository => _userRepository.Value;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (_connection != null)
                    {
                        _transaction?.Dispose();
                        _connection.Dispose();
                    }
                }

                _connection = null;
                _transaction = null;
            }

            _isDisposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}