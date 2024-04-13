using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Repository;
using StoreManager.Service.Interfaces.Repositories;
namespace StoreManager.Tests.Repository_Tests;

[Collection("Collection1")]
public class CountryRepositoryTest : RepositoryTestBase, IDisposable
{
    [Fact]
    public void CountryInsert()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
        Country country = new() { Name = "Country1" };

        int id = unitOfWork.CountryRepository.Insert(country);

        Assert.NotEqual(0, id);
        Country retriavedCountry = unitOfWork.CountryRepository.Get(id);
        Assert.Equal(retriavedCountry.Name, country.Name);
    }

    [Fact]
    public void UpdateCountry()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
        Country insertedCountry = new() { Name = "Country1" };
        int id = unitOfWork.CountryRepository.Insert(insertedCountry);

        Country updatedCountry = new() { CountryId = id, Name = "Country 1" };
        unitOfWork.CountryRepository.Update(updatedCountry);

        Country retriavedCountry = unitOfWork.CountryRepository.Get(id);

        Assert.Equal(retriavedCountry.Name, updatedCountry.Name);

    }

    public override void Dispose()
    {
        SqlCommand command = _connection.CreateCommand();
        _connection.Open();
        command.CommandText = "Delete Countries; DBCC CHECKIDENT ('Countries', RESEED, 0)";
        command.ExecuteNonQuery();
        _connection.Dispose();
    }
}
