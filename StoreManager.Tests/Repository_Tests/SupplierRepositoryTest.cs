using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Repository;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Tests.Repository_Tests
{
    [Collection("Collection1")]
    public class SupplierRepositoryTest : RepositoryTestBase
    {
        public SupplierRepositoryTest()
        {
            SqlCommand command = _connection.CreateCommand();
            _connection.Open();
            command.CommandText = "Insert Into Countries(Name) values('Country2') " +
                            "Insert Into Cities(CountryID, Name) values(1,'City2') ";
            command.ExecuteNonQuery();
        }

        [Fact]
        public void InsertSupplier()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            Supplier supplier = new() { CityId = 1, Name = "Supplier1", TaxCode = "Code", Email = "Mail", Phone = "Phone" };

            int id = unitOfWork.SupplierRepository.Insert(supplier);

            Assert.NotEqual(0, id);
            Supplier retriavedSupplier = unitOfWork.SupplierRepository.Get(id);
            Assert.Equal(retriavedSupplier.Name, supplier.Name);
            Assert.Equal(retriavedSupplier.Email, supplier.Email);
            Assert.Equal(retriavedSupplier.CityId, supplier.CityId);
        }

        [Fact]
        public void UpdateSupplier()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            Supplier supplier = new() { CityId = 1, Name = "Supplier1", TaxCode = "Code", Email = "Mail", Phone = "Phone" };

            int id = unitOfWork.SupplierRepository.Insert(supplier);

            Supplier updatedSupplier = new() { SupplierId = id, CityId = 1, Name = "UpdatedName", Email = "UpdatedMain", Phone = "UpdatedPhone", TaxCode = "-" };
            unitOfWork.SupplierRepository.Update(updatedSupplier);

            Supplier retriavedSupplier = unitOfWork.SupplierRepository.Get(id);
            Assert.Equal(retriavedSupplier.Name, updatedSupplier.Name);
            Assert.Equal(retriavedSupplier.CityId, updatedSupplier.CityId);
            Assert.Equal(retriavedSupplier.Email, updatedSupplier.Email);
        }

        public override void Dispose()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "Delete Suppliers;  DBCC CHECKIDENT('Suppliers', RESEED, 0) " +
                           "Delete Cities;  DBCC CHECKIDENT('Cities', RESEED, 0) " +
                           "Delete Countries; DBCC CHECKIDENT('Countries', RESEED, 0) ";
            command.ExecuteNonQuery();
            base.Dispose();
        }
    }
}
