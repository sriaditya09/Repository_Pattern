using System.Text.Json.Serialization;

namespace Repository_Pattern.Model.Entity
{
	public class Brand
	{
		public int Id { get; set; }
		public string Brand_Name { get; set; }

		public string Brand_Country { get; set; }

		public int ProductId { get; set; }
		
	}
}
