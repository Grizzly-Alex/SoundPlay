using Microsoft.EntityFrameworkCore;
using SoundPlay.DAL.Data.ModelConfigurations;
using SoundPlay.DAL.Models;

namespace SoundPlay.DAL.Data
{
	public sealed class ApplicationDbContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<GuitarShape> GuitarShapes { get; set; }
		public DbSet<Material> Materials { get; set; }
		public DbSet<TremoloType> TremoloTypes { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new CategoryModelConfiguration());
			builder.ApplyConfiguration(new BrandModelConfiguration());
			builder.ApplyConfiguration(new GuitarShapeModelConfiguration());
			builder.ApplyConfiguration(new MaterialModelConfiguration());
			builder.ApplyConfiguration(new TremoloTypeModelConfiguration());
		}
	}
}
