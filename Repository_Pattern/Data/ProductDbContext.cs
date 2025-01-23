using Microsoft.EntityFrameworkCore;
using Repository_Pattern.Model.Entity;

namespace Repository_Pattern.Data
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Brand> Brands { get; set; }
		public DbSet<Product> products { get; set; }
		public DbSet<productDetails> details { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// One-to-many relationship between Product and Brand
			modelBuilder.Entity<Brand>()
				.HasOne<Product>()
				.WithMany(p => p.Brands)  // A Product has many Brands
				.HasForeignKey(b => b.ProductId); // Foreign key in Brand

			// One-to-many relationship between Product and ProductDetails
			modelBuilder.Entity<productDetails>()
				.HasOne<Product>()
				.WithMany(p => p.ProductDetails)  // A Product has many ProductDetails
				.HasForeignKey(pd => pd.ProductId);  // Foreign key in ProductDetails
		}
	}
}
 