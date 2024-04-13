using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Repository;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Tests.Repository_Tests
{
    [Collection("Collection1")]
    public class EmployeeRepositoryTest : RepositoryTestBase
    {
        public EmployeeRepositoryTest()
        {
            SqlCommand command = _connection.CreateCommand();
            _connection.Open();
            command.CommandText = "Insert Into Countries(Name) values('Country1') " +
                            "Insert Into Cities(CountryID, Name) values(1,'City1') " +
                            "Insert Into EmployeeTypes(Name) values('Type1')";
            command.ExecuteNonQuery();
        }

        [Fact]
        public void InsertEmployee()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            Employee employee = new() { EmployeeTypeId = 1, CityId = 1, FirstName = "FirstName", LastName = "LastName", IdentityNumber = "123", Email = "@Email", Phone = "Phone" };

            int id = unitOfWork.EmployeeRepository.Insert(employee);

            Assert.NotEqual(0, id);
            Employee retriavedEmployee = unitOfWork.EmployeeRepository.Get(id);

            Assert.Equal(employee.EmployeeTypeId, retriavedEmployee.EmployeeTypeId);
            Assert.Equal(employee.FirstName, retriavedEmployee.FirstName);
            Assert.Equal(employee.LastName, retriavedEmployee.LastName);
            Assert.Equal(employee.CityId, retriavedEmployee.CityId);
        }

        [Fact]
        public void UpdateEmployee()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            Employee employee = new() { EmployeeTypeId = 1, CityId = 1, FirstName = "FirstName", LastName = "LastName", IdentityNumber = "123", Email = "@Email", Phone = "Phone" };

            int id = unitOfWork.EmployeeRepository.Insert(employee);

            Employee updatedEmployee = new() { EmployeeId = id, EmployeeTypeId = 1, CityId = 1, FirstName = "UpdatedFirstName", LastName = "UpdatedLastName", IdentityNumber = "Updated123", Email = "@Email", Phone = "Phone" };
            unitOfWork.EmployeeRepository.Update(updatedEmployee);

            Employee retriavedEmployee = unitOfWork.EmployeeRepository.Get(id);
            Assert.Equal(retriavedEmployee.FirstName, updatedEmployee.FirstName);
            Assert.Equal(retriavedEmployee.LastName, updatedEmployee.LastName);
            Assert.Equal(retriavedEmployee.IdentityNumber, updatedEmployee.IdentityNumber);

        }
        public override void Dispose()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "Delete Employees;  DBCC CHECKIDENT('Employees', RESEED, 0) " +
                            "Delete Cities;  DBCC CHECKIDENT('Cities', RESEED, 0) " +
                            "Delete Countries; DBCC CHECKIDENT('Countries', RESEED, 0) " +
                            "Delete EmployeeTypes;  DBCC CHECKIDENT('EmployeeTypes', RESEED, 0)";
            command.ExecuteNonQuery();
            base.Dispose();
        }
    }
}
