using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundPlay.DTO.Models;

namespace SoundPlay.DAL.Data.ModelConfigurations
{
	internal class MaterialModelConfiguration : IEntityTypeConfiguration<Material>
	{
		public void Configure(EntityTypeBuilder<Material> builder)
		{
			builder.ToTable("Materials")
				.HasKey(p => p.Id)
				.HasName("MaterialId");

			builder.Property(p => p.Id)
				.HasColumnName("MaterialId");

			builder.Property(p => p.Name)
				.HasColumnName("MaterialName")
				.IsRequired();
		}
	}
}