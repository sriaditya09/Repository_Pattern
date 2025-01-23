namespace Repository_Pattern.Repository;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository_Pattern.Data;
using Repository_Pattern.Interface;
using Repository_Pattern.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductRepository : IProductRepository
{

	private readonly ProductDbContext _context;

	public ProductRepository(ProductDbContext context)
	{
		_context = context;
	}
	public async Task<List<Product>> GetAllProducts()
	{
		var allproducts = await _context.products
				.Include(a => a.Brands)
				.Include(a => a.ProductDetails)
				.ToListAsync();
		return allproducts;
	}
	public async Task AddProduct(Product product)
	{
		var result = await _context.AddAsync(product);
		await _context.SaveChangesAsync();

	}
    public async Task<Product> GetProductById(int id)
	{
		return await _context.products
			.Include(p => p.Brands)
			.Include(p => p.ProductDetails)
			.FirstOrDefaultAsync(p => p.Id == id);
	}
	public async Task<Product> DeleteProduct(int id)
	{
		var product = await _context.products
		.Include(p => p.Brands)
		.Include(p => p.ProductDetails)
		.FirstOrDefaultAsync(p => p.Id == id);

		if (product == null)
		{
			return null; // Return false if product is not found
		}
		_context.Brands.RemoveRange(product.Brands);
		_context.details.RemoveRange(product.ProductDetails);
		_context.products.Remove(product);

		await _context.SaveChangesAsync();

		return product;

	}

	public async Task<Product> UpdateProduct(int id, Product product)
	{
		
		var existingProduct = await _context.products
			.Where(p => p.Id == id)
			.FirstOrDefaultAsync();

		
		existingProduct.ProductName = product.ProductName ?? existingProduct.ProductName;
		existingProduct.ProductRegN = product.ProductRegN ?? existingProduct.ProductRegN;

		await _context.SaveChangesAsync();

		return existingProduct;
	}

}





