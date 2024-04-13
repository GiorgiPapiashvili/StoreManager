using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Repository;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Tests.Repository_Tests
{
    [Collection("Collection1")]
    public class PurchaseRepositoryTest : RepositoryTestBase
    {
        public PurchaseRepositoryTest()
        {
            SqlCommand command = _connection.CreateCommand();
            _connection.Open();
            command.CommandText = "Insert Into Countries(Name) values('Country3') " +
                            "Insert Into Cities(CountryID, Name) values(1,'City3') " +
                            "Insert Into EmployeeTypes(Name) values('Type2')" +
                            "Insert Into Employees(EmployeeTypeId, FirstName, LastName, IdentityNumber, Email, Phone, Cityid) values(1,'Name','Lastname', '-', '-', '-', 1)" +
                            "Insert Into Suppliers(Name, TaxCode, Email, Phone, CityId) values('Name1', 'Code', 'GMail', 'Phone', 1)";
            command.ExecuteNonQuery();
        }

        [Fact]
        public void InsertPurchase()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            Purchase purchase = new() { EmployeeId = 1, SupplierId = 1, Status = SignStatus.InProgress };

            int id = unitOfWork.PurchaseRepository.Insert(purchase);

            Assert.NotEqual(0, id);
            Purchase retriavedPurchase = unitOfWork.PurchaseRepository.Get(id);
            Assert.Equal(retriavedPurchase.SupplierId, purchase.SupplierId);
            Assert.Equal(retriavedPurchase.EmployeeId, purchase.EmployeeId);
            Assert.Equal(retriavedPurchase.Status, purchase.Status);
        }

        [Fact]
        public void UpdatePurchase()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            Purchase purchase = new() { EmployeeId = 1, SupplierId = 1, Status = SignStatus.InProgress };
            int id = unitOfWork.PurchaseRepository.Insert(purchase);

            Purchase updatedPurchase = new() { PurchaseId = id, Status = SignStatus.Completed };
            unitOfWork.PurchaseRepository.Update(updatedPurchase);

            Purchase retriavedPurchase = unitOfWork.PurchaseRepository.Get(id);
            Assert.Equal(retriavedPurchase.Status, updatedPurchase.Status);
        }

        public override void Dispose()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "Delete Purchases; DBCC CHECKIDENT('Purchases', RESEED, 0)" +
                            "Delete Employees;  DBCC CHECKIDENT('Employees', RESEED, 0) " +
                            "Delete Suppliers; DBCC CHECKIDENT('Suppliers', RESEED, 0)" +
                            "Delete Cities;  DBCC CHECKIDENT('Cities', RESEED, 0) " +
                            "Delete Countries; DBCC CHECKIDENT('Countries', RESEED, 0) " +
                            "Delete EmployeeTypes;  DBCC CHECKIDENT('EmployeeTypes', RESEED, 0)";
            command.ExecuteNonQuery();
            base.Dispose();
        }
    }
}
