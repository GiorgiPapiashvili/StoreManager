using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;
using StoreManager.Service.Interfaces.Services;

namespace StoreManager.Service;

public class ProductService : IProductService
{
	private readonly IUnitOfWork _unitOfWork;

	public ProductService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public int Insert(Product product)
	{
		if (product == null) throw new ArgumentNullException(nameof(product));

		try
		{
			_unitOfWork.BeginTransaction();
			int id = _unitOfWork.ProductRepository.Insert(product);
			_unitOfWork.CommitTransaction();
			return id;
		}
		catch
		{
			_unitOfWork.RollBackTransaction();
			throw;
		}
	}

	public void Insert(IEnumerable<Product> products)
	{
		if (products == null) throw new ArgumentNullException(nameof(products));

		try
		{
			_unitOfWork.BeginTransaction();
			products
				.ToList()
				.ForEach(p => _unitOfWork.ProductRepository.Insert(p));
			_unitOfWork.CommitTransaction();
		}
		catch
		{
			_unitOfWork.RollBackTransaction();
			throw;
		}
	}

	public void Update(Product product)
	{
		if (product == null) throw new ArgumentNullException(nameof(product));

		try
		{
			_unitOfWork.BeginTransaction();
			_unitOfWork.ProductRepository.Update(product);
			_unitOfWork.CommitTransaction();
		}
		catch
		{
			_unitOfWork.RollBackTransaction();
			throw;
		}
	}

	public void Delete(int Id)
	{
		try
		{
			_unitOfWork.BeginTransaction();
			_unitOfWork.ProductRepository.Delete(Id);
			_unitOfWork.CommitTransaction();
		}
		catch
		{
			_unitOfWork.RollBackTransaction();
			throw;
		}
	}

	public Product Get(int id)
	{
		return _unitOfWork.ProductRepository.Get(id);
	}
}
