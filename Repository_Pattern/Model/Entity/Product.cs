using System.Net;
using System.Text.Json.Serialization;

namespace Repository_Pattern.Model.Entity
{
	public class Product
	{
		public int Id { get; set; }
		public string ProductName { get; set; }
		public string ProductRegN { get; set; }

		// Navigation properties for related entities
		public List<Brand> Brands { get; set; }
		public List<productDetails> ProductDetails { get; set; }
	}
}
