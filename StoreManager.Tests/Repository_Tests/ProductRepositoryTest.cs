using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Repository;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Tests.Repository_Tests
{
    [Collection("Collection1")]
    public class ProductRepositoryTest : RepositoryTestBase
    {
        public ProductRepositoryTest()
        {
            SqlCommand command = _connection.CreateCommand();
            _connection.Open();
            command.CommandText = "Insert into Categories(Name) values('Category2')";
            command.ExecuteNonQuery();
        }

        [Fact]
        public void InsertProduct()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            Product product = new() { CategoryId = 1, ProductCode = "111", Name = "Product1", UnitPrice = 12.22m };

            int id = unitOfWork.ProductRepository.Insert(product);

            Assert.NotEqual(0, id);
            Product retriavedProduct = unitOfWork.ProductRepository.Get(id);
            Assert.Equal(product.Name, retriavedProduct.Name);
            Assert.Equal(product.UnitPrice, retriavedProduct.UnitPrice);
            Assert.Equal(product.CategoryId, retriavedProduct.CategoryId);
        }

        [Fact]
        public void UpdateProduct()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            Product product = new() { CategoryId = 1, ProductCode = "111", Name = "Product1", UnitPrice = 12.22m };

            int id = unitOfWork.ProductRepository.Insert(product);
            Product updatedProduct = new() { ProductId = id, CategoryId = 1, Name = "UpdatedProduct", ProductCode = "UpdatedCode", UnitPrice = 12.32m, Description = "Description" };
            unitOfWork.ProductRepository.Update(updatedProduct);

            Product retriavedProduct = unitOfWork.ProductRepository.Get(id);
            Assert.Equal(retriavedProduct.Name, updatedProduct.Name);
            Assert.Equal(retriavedProduct.Description, updatedProduct.Description);
        }

        public override void Dispose()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "Delete Products; DBCC CHECKIDENT('Products', RESEED, 0)" +
                            "Delete Categories; DBCC CHECKIDENT('Categories', RESEED, 0)";
            command.ExecuteNonQuery();
            base.Dispose();
        }
    }
}
