using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Repository;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Tests.Repository_Tests
{
    [Collection("Collection1")]
    public class EmployeeTypeRepositoryTest : RepositoryTestBase
    {
        [Fact]
        public void InsertEmployeeType()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            EmployeeType employeeType = new() { Name = "Type1" };

            int id = unitOfWork.EmployeeTypeRepository.Insert(employeeType);

            Assert.NotEqual(0, id);
            EmployeeType retriavedEmployeeType = unitOfWork.EmployeeTypeRepository.Get(id);
            Assert.Equal(employeeType.Name, retriavedEmployeeType.Name);
        }

        [Fact]
        public void UpdateEmployeeType()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            EmployeeType employeeType = new() { Name = "Type1" };
            int id = unitOfWork.EmployeeTypeRepository.Insert(employeeType);

            EmployeeType updatedEmployeeType = new() { EmployeeTypeId = id, Name = "UpdatedType1", Description = "Description" };
            unitOfWork.EmployeeTypeRepository.Update(updatedEmployeeType);

            EmployeeType retriavedtype = unitOfWork.EmployeeTypeRepository.Get(id);
            Assert.Equal(retriavedtype.Name, updatedEmployeeType.Name);
            Assert.Equal(retriavedtype.Description, updatedEmployeeType.Description);
        }

        public override void Dispose()
        {
            SqlCommand command = _connection.CreateCommand();
            _connection.Open();
            command.CommandText = "Delete EmployeeTypes; DBCC CHECKIDENT('EmployeeTypes', RESEED, 0)";
            command.ExecuteNonQuery();
            base.Dispose();
        }
    }
}
