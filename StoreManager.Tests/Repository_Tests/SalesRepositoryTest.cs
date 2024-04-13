using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Repository;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Tests.Repository_Tests
{
    [Collection("Collection1")]
    public class SalesRepositoryTest : RepositoryTestBase
    {
        public SalesRepositoryTest()
        {
            SqlCommand command = _connection.CreateCommand();
            _connection.Open();
            command.CommandText = "Insert Into Countries(Name) values('Country1') " +
                            "Insert Into Cities(CountryID, Name) values(1,'City1') " +
                            "Insert Into EmployeeTypes(Name) values('Type1')" +
                            "Insert Into Employees(EmployeeTypeId, FirstName, LastName, IdentityNumber, Email, Phone, CityId) values(1, 'Name', 'LastName','-','Mail','-',1)" +
                            "Insert Into Customers(FirstName, LastName, Email, Phone, CityId) values('Name', 'LastName','-','Mail', 1)";
            command.ExecuteNonQuery();
        }

        [Fact]
        public void InsertSales()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            Sale sale = new() { CustomerId = 1, EmployeeId = 1, Status = SignStatus.InProgress };

            int id = unitOfWork.SaleRepository.Insert(sale);

            Assert.NotEqual(0, id);
            Sale retriavedSale = unitOfWork.SaleRepository.Get(id);
            Assert.Equal(retriavedSale.EmployeeId, sale.EmployeeId);
            Assert.Equal(retriavedSale.CustomerId, sale.CustomerId);
            Assert.Equal(retriavedSale.Status, sale.Status);
        }

        [Fact]
        public void UpdateSales()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            Sale sale = new() { EmployeeId = 1, CustomerId = 1, Status = SignStatus.InProgress };
            int id = unitOfWork.SaleRepository.Insert(sale);

            Sale updatedSale = new() { SaleId = id, Status = SignStatus.Completed };
            unitOfWork.SaleRepository.Update(updatedSale);

            Sale retriavedSale = unitOfWork.SaleRepository.Get(id);
            Assert.Equal(retriavedSale.Status, updatedSale.Status);

        }

        public override void Dispose()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "Delete Sales;  DBCC CHECKIDENT('Sales', RESEED, 0) " +
                            "Delete Employees;  DBCC CHECKIDENT('Employees', RESEED, 0) " +
                            "Delete Customers;  DBCC CHECKIDENT('Customers', RESEED, 0)" +
                            "Delete Cities;  DBCC CHECKIDENT('Cities', RESEED, 0) " +
                            "Delete Countries; DBCC CHECKIDENT('Countries', RESEED, 0) " +
                            "Delete EmployeeTypes;  DBCC CHECKIDENT('EmployeeTypes', RESEED, 0)";
            command.ExecuteNonQuery();
            base.Dispose();
        }
    }
}
