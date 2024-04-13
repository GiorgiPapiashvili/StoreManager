using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Repository;
using StoreManager.Service;
using StoreManager.Service.Interfaces.Repositories;
using System.Data.Common;

namespace StoreManager.Tests.Service_Tests
{
    public class ProducServiceTest : ServiceTestBase
    {
        public ProducServiceTest()
        {
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Insert into Categories(Name) values('Category2')";
            command.ExecuteNonQuery();
        }

        [Fact]
        public void InserProduct()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
            ProductService service = new(unitOfWork);
            Product product = new() { CategoryId = 1, ProductCode = "111", Name = "Product1", UnitPrice = 12.22m };

            int id =  service.Insert(product);
            
            Assert.NotEqual(0, id);
            Product retriavedProduct = service.Get(id);
            Assert.Equal(product.Name, retriavedProduct.Name);
            Assert.Equal(product.UnitPrice, retriavedProduct.UnitPrice);
            Assert.Equal(product.CategoryId, retriavedProduct.CategoryId);
        }

        public override void Dispose()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "Delete Products; DBCC CHECKIDENT('Products', RESEED, 0)" +
                            "Delete Categories; DBCC CHECKIDENT('Categories', RESEED, 0)";
            command.ExecuteNonQuery();
            base.Dispose();
        }
    }
}
