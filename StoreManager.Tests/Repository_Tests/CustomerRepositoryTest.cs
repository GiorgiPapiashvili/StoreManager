using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Repository;
using StoreManager.Service.Interfaces.Repositories;
namespace StoreManager.Tests.Repository_Tests;

[Collection("Collection1")]
public class CustomerRepositoryTest : RepositoryTestBase, IDisposable
{
    public CustomerRepositoryTest()
    {
        SqlCommand command = _connection.CreateCommand();
        _connection.Open();
        command.CommandText = "Insert into Countries(name) values('Country3')" +
                "Insert into Cities(name, CountryId) values('City1',1)";
        command.ExecuteNonQuery();
    }

    [Fact]
    public void Insert_InsertCustomer()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
        Customer customer = new() { FirstName = "FirstName1", LastName = "LastName1", CityId = 1 };

        int id = unitOfWork.CustomerRepository.Insert(customer);

        Assert.NotEqual(0, id);
        Customer retriavedCustomer = unitOfWork.CustomerRepository.Get(id);

        Assert.Equal(retriavedCustomer.FirstName, customer.FirstName);
        Assert.Equal(retriavedCustomer.LastName, customer.LastName);
        Assert.Equal(retriavedCustomer.CityId, customer.CityId);
    }

    public override void Dispose()
    {
        SqlCommand command = _connection.CreateCommand();
        command.CommandText = "Delete Customers; DBCC CHECKIDENT ('Customers', RESEED, 0)"
            + "Delete Cities; DBCC CHECKIDENT ('Cities', RESEED, 0)" +
            "Delete Countries; DBCC CHECKIDENT ('Countries', RESEED, 0)";
        command.ExecuteNonQuery();
        _connection.Dispose();
    }
}
