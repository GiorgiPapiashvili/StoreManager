using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Repository;
using StoreManager.Service.Interfaces.Repositories;
namespace StoreManager.Tests.Repository_Tests;

[Collection("Collection1")]
public class CityRepositoryTest : RepositoryTestBase, IDisposable
{
    public CityRepositoryTest()
    {
        SqlCommand command = _connection.CreateCommand();
        _connection.Open();
        command.CommandText = "insert into countries(name) values('Country1');";
        command.ExecuteNonQuery();
    }

    [Fact]
    public void Insert_InsertCity()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
        City city = new() { CountryId = 1, Name = "City1" };

        int id = unitOfWork.CityRepository.Insert(city);

        Assert.NotEqual(0, id);
        City retriavedCity = unitOfWork.CityRepository.Get(id);
        Assert.Equal(city.CountryId, retriavedCity.CountryId);
        Assert.Equal(city.Name, retriavedCity.Name);
    }

    public override void Dispose()
    {
        SqlCommand command = _connection.CreateCommand();
        command.CommandText = "Delete Cities; DBCC CHECKIDENT ('Cities', RESEED, 0)" +
            "Delete Countries; DBCC CHECKIDENT ('Countries', RESEED, 0)";
        command.ExecuteNonQuery();
        _connection.Dispose();
    }
}
