namespace StoreManager.Tests.Repository_Tests;
using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Repository;
using StoreManager.Service.Interfaces.Repositories;

[Collection("Collection2")]
public class CategoryRepositoryTest : RepositoryTestBase
{
    [Fact]
    public void InsertCategory()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
        Category category = new() { Name = "Category1" };

        int id = unitOfWork.CategoryRepository.Insert(category);

        Assert.NotEqual(0, id);
        var retriavedCategory = unitOfWork.CategoryRepository.Get(id);
        Assert.Equal(retriavedCategory.Name, category.Name);
    }

    [Fact]
    public void UpdateCategory()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
        Category insertedCategory = new Category() { Name = "Category1" };

        int id = unitOfWork.CategoryRepository.Insert(insertedCategory);

        Category updatedCategory = new() { CategoryId = id, Name = "Category2", Description = "Description" };
        unitOfWork.CategoryRepository.Update(updatedCategory);

        Category retriavedCategory = unitOfWork.CategoryRepository.Get(id);

        Assert.Equal(retriavedCategory.Description, updatedCategory.Description);
        Assert.Equal(retriavedCategory.Name, updatedCategory.Name);
    }

    //[Fact]
    //public void DeleteCategory()
    //{
    //    CategoryRepository categoryRepository = new(ConnectionString);
    //    Category insertedCategory = new() { Name = "Category1" };
    //    int id = categoryRepository.Insert(insertedCategory);

    //    categoryRepository.Delete(id);

    //    Category retriavedCategory = categoryRepository.Get(id);

    //    Assert.True(retriavedCategory.IsDeleted);
    //}

    public override void Dispose()
    {
        SqlCommand command = _connection.CreateCommand();
        _connection.Open();
        command.CommandText = "Delete categories; DBCC CHECKIDENT ('categories', RESEED, 0)";
        command.ExecuteNonQuery();
        _connection.Dispose();
    }
}