using System.Text.Json.Serialization;

namespace Repository_Pattern.Model.Entity
{
	public class productDetails
	{
		public int Id { get; set; }
		public string Store_city { get; set; }
		public bool IsAvailable { get; set; }

		public int ProductId { get; set; }


	}
}
