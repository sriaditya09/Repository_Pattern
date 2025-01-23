using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.Data;
using Repository_Pattern.Model.Entity;
using Repository_Pattern.Repository;

namespace Repository_Pattern.Interface
{
	public interface IProductRepository
	{
		Task<List<Product>> GetAllProducts();
		Task AddProduct(Product product);


		Task<Product> GetProductById(int id);

		Task<Product> DeleteProduct(int id);

		Task<Product> UpdateProduct(int id, Product product);
	}
}
