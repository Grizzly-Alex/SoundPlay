using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundPlay.DAL.Models;

namespace SoundPlay.DAL.Data.ModelConfigurations
{
	internal class GuitarShapeModelConfiguration : IEntityTypeConfiguration<GuitarShape>
	{
		public void Configure(EntityTypeBuilder<GuitarShape> builder)
		{
			builder.ToTable("GuitarShapes")
				.HasKey(p => p.Id)
				.HasName("ShapeId");

			builder.Property(p => p.Id)
				.HasColumnName("ShapeId");

			builder.Property(p => p.Name)
				.HasColumnName("ShapeName")
				.IsRequired();
		}
	}
}