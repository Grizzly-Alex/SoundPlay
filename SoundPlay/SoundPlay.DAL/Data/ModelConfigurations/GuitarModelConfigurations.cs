using Microsoft.EntityFrameworkCore;

namespace SoundPlay.DAL.Data.ModelConfigurations;

internal sealed class GuitarModelConfiguration : IEntityTypeConfiguration<Guitar>
{
    public void Configure(EntityTypeBuilder<Guitar> builder)
    {
        builder.Property(p => p.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(max)")
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(max)")
            .IsRequired();

		builder.Property(p => p.PictureUrl)
			.HasColumnName("picture_url")
			.HasColumnType("varchar(max)")
			.IsRequired();

		builder.Property(p => p.Price)
            .HasColumnName("price")
            .HasColumnType("decimal")
            .HasPrecision(8, 2)
            .IsRequired();

        builder.Property(p => p.DateDelivery)
            .HasColumnName("date_delivery")
            .HasColumnType("datetime2(7)");

		builder.Property(p => p.BrandId)
			.IsRequired()
			.HasColumnName("brand_id")
	        .HasColumnType("int");

		builder.Property(p => p.ColorId)
			.IsRequired()
			.HasColumnName("color_id")
	        .HasColumnType("int");

		builder.Property(p => p.GuitarCategory)
			.HasColumnName("category")
			.HasConversion(p => p.ToString(), p => Enum.Parse<GuitarCategory>(p))
			.IsRequired();

		builder.Property(p => p.FretsCount)
	        .HasColumnName("frets_count")
	        .HasColumnType("tinyint")
	        .IsRequired();

		builder.Property(p => p.StringsCount)
			.HasColumnName("strings_count")
			.HasColumnType("tinyint")
			.IsRequired();

        builder.Property(p => p.ShapeId)
            .HasColumnName("shape_id")
            .HasColumnType("int");

		builder.Property(p => p.SoundboardId)
            .HasColumnName("soundboard_id")
            .HasColumnType("int")
			.IsRequired();

		builder.Property(p => p.NeckId)
	        .HasColumnName("neck_id")
	        .HasColumnType("int")
	        .IsRequired();

		builder.Property(p => p.FretboardId)
	        .HasColumnName("fretboard_id")
	        .HasColumnType("int")
	        .IsRequired();

		builder.Property(p => p.TremoloTypeId)
	        .HasColumnName("tremolo_id")
	        .HasColumnType("int");

		builder.Property(p => p.PickupSetId)
	        .HasColumnName("pickup_set_id")
	        .HasColumnType("int");   
    }   
}
