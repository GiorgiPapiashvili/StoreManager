namespace StoreManager.Service.Interfaces.Repositories;

public interface IRepositoryBase<T>
{
    T Get(int id);
    IEnumerable<T> Load();
    int Insert(T item);
    void Update(T item);
    void Delete(int id);
}