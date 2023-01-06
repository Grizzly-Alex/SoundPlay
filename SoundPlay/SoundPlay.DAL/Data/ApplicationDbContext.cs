using Microsoft.EntityFrameworkCore;
using SoundPlay.DAL.Data.ModelConfigurations;
using SoundPlay.DTO.Models;

namespace SoundPlay.DAL.Data
{
	public sealed class ApplicationDbContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new CategoryModelConfiguration());
		}
	}
}
