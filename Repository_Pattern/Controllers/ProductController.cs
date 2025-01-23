using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository_Pattern.Interface;
using Repository_Pattern.Model.Entity;
using Repository_Pattern.Repository;

namespace Repository_Pattern.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository productRepository;

		public ProductController(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			var products = await productRepository.GetAllProducts();
			return Ok(products);
		}


		[HttpPost]
		public async Task<IActionResult> CreateProduct([FromBody] Product product)
		{
			if (product == null)
			{
				return BadRequest("Product data is null.");
			}
			 product = new Product
			{
				ProductName = product.ProductName,
				ProductRegN = product.ProductRegN,
				Brands = product.Brands
				.Select(a => new Brand
				{
					Brand_Name = a.Brand_Name,
					Brand_Country = a.Brand_Country,
				}).ToList(),
				ProductDetails = product.ProductDetails.Select(b => new productDetails
				{
					Store_city = b.Store_city,
					IsAvailable = b.IsAvailable,
				}).ToList()
			};
			// Add product to repository
			await productRepository.AddProduct(product);

			// Return Created response with the new product
			return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, product);
			//return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
		{
			var updatedProduct = await productRepository.UpdateProduct(id, product);

			return Ok(updatedProduct);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var result = await productRepository.DeleteProduct(id);

			if (result != null)
			{
				return Ok(result);
			}
			else
			{
				return NotFound($"Product Id {id} not found."); // Return HTTP 404 if product doesn't exist
			}
		}

	}
}
