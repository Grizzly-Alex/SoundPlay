using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundPlay.DTO.Models;

namespace SoundPlay.DAL.Data.ModelConfigurations
{
	internal class CategoryModelConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Categories")
				.HasKey(p => p.Id)
				.HasName("CategoryId");

			builder.Property(p => p.Id)
				.HasColumnName("CategoryId");

			builder.Property(p => p.Name)
				.HasColumnName("CategoryName")
				.HasColumnType("varchar(30)")
				.IsRequired();
		}
	}
}