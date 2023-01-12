using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundPlay.DAL.Models;

namespace SoundPlay.DAL.Data.ModelConfigurations
{
	internal sealed class GuitarModelConfiguration : IEntityTypeConfiguration<Guitar>
	{
		public void Configure(EntityTypeBuilder<Guitar> builder)
		{
			builder.ToTable("Brands")
				.HasKey(p => p.Id)
				.HasName("GuitarId");

            builder.Property(p => p.Id)
				.HasColumnName("GuitarId")
				.IsRequired();

			builder.Property(p => p.Name)
				.HasColumnName("Name")
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder.Property(p => p.FrestCount)
				.HasColumnName("FreastCount")
				.HasColumnType("integer(24) unsigned")
				.IsRequired();

            builder.Property(p => p.StringsCount)
                .HasColumnName("StringsCount")
                .HasColumnType("integer(12) unsigned")
                .IsRequired();

            builder.Property(p => p.Description)
				.HasColumnName("Discription")
				.IsRequired();

            builder.Property(p => p.Price)
				.HasColumnName("Price")
				.HasColumnType("decimal")
                .HasPrecision(8, 2)
				.IsRequired();

            builder.Property(p => p.PictureUrl)
                .HasColumnName("PictureUrl")
				.HasColumnName("varchar(max)")
                .IsRequired();

			builder.Property(p => p.Category)
				.HasColumnName("CategoryId")
				.HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Brand)
				.HasColumnName("BrandId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Color)
                .HasColumnName("ColorId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Shape)
				.HasColumnName("ShapeId")
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(p => p.Soundboard)
				.HasColumnName("SoundboardMaterialId")
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(p => p.Neck)
				.HasColumnName("NeckMaterialId")
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(p => p.Fretboard)
				.HasColumnName("FretboardMaterialId")
                .HasColumnType("int")
                .IsRequired(false);

			builder.Property(p => p.PickupSet)
				.HasColumnName("PickupSetId")
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(p => p.TremoloType)
				.HasColumnName("TremoloTypeId")
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(p => p.DateDelivery)
				.HasColumnName("DateDelivery")
				.HasColumnType("datetime")
				.HasConversion(t => t.TimeOfDay, t => DateTime.Now.Date.Add(t))
				.IsRequired();
        }
	}
}