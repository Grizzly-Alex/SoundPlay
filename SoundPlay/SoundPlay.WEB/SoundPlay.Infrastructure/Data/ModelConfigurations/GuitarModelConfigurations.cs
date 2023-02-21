namespace SoundPlay.DAL.Data.ModelConfigurations;

internal sealed class GuitarModelConfiguration : IEntityTypeConfiguration<Guitar>
{
    public void Configure(EntityTypeBuilder<Guitar> builder)
    {
        #region Properties
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

		builder.Property(p => p.FretsCount)
	        .HasColumnName("frets_count")
	        .HasColumnType("tinyint")
	        .IsRequired();

		builder.Property(p => p.StringsCount)
			.HasColumnName("strings_count")
			.HasColumnType("tinyint")
			.IsRequired();

		builder.Property(p => p.CategoryId)
			.HasColumnName("category_id")
            .HasColumnType("int")
			.HasDefaultValue(1)
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
        #endregion

        #region ForeignKey
        builder.HasOne(y => y.Brand)
			.WithMany(x => x.Guitars)
            .HasForeignKey(x => x.BrandId)
			.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(y => y.Color)
			.WithMany(x => x.Guitars)
			.HasForeignKey(x => x.ColorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(y => y.Category)
			.WithMany(x => x.Guitars)
			.HasForeignKey(x => x.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(y => y.Shape)
            .WithMany(x => x.Guitars)
            .HasForeignKey(x => x.ShapeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(y => y.Soundboard)
			.WithMany(x => x.GuitarsOfSoundboard)
			.HasForeignKey(x => x.SoundboardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(y => y.Neck)
            .WithMany(x => x.GuitarsOfNeck)
            .HasForeignKey(x => x.NeckId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(y => y.Fretboard)
            .WithMany(x => x.GuitarsOfFretboard)
            .HasForeignKey(x => x.FretboardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(y => y.PickupSet)
            .WithMany(x => x.Guitars)
            .HasForeignKey(x => x.PickupSetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(y => y.TremoloType)
			.WithMany(x => x.Guitars)
			.HasForeignKey(x => x.TremoloTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion
    }
}
