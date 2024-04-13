using StoreManager.DTO;

namespace StoreManager.Service.Interfaces.Services;

public interface IProductService
{
    int Insert(Product item);
    void Update(Product item);
    void Delete(int id);
    Product Get(int id);
}
