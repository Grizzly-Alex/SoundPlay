namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class GuitarConfiguration : IEntityTypeConfiguration<Guitar>
{
    public void Configure(EntityTypeBuilder<Guitar> builder)
    {
        #region Properties
        builder.Property(p => p.Id)
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnType("varchar(max)")
            .IsRequired();

        builder.Property(p => p.Stock)
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnType("varchar(max)")
            .IsRequired();

		builder.Property(p => p.PictureUrl)
			.HasColumnType("varchar(max)")
			.IsRequired(false);

		builder.Property(p => p.Price)
            .HasColumnType("decimal")
            .HasPrecision(8, 2)
            .IsRequired();

        builder.Property(p => p.DateDelivery)
            .HasColumnType("datetime2(7)");

		builder.Property(p => p.BrandId)
	        .HasColumnType("int");

		builder.Property(p => p.ColorId)
			.IsRequired()
	        .HasColumnType("int");

		builder.Property(p => p.FretsCount)
	        .HasColumnType("tinyint")
	        .IsRequired();

		builder.Property(p => p.StringsCount)
			.HasColumnType("tinyint")
			.IsRequired();

		builder.Property(p => p.CategoryId)
            .HasColumnType("int")
			.HasDefaultValue(1)
			.IsRequired();

        builder.Property(p => p.ShapeId)
            .HasColumnType("int");

		builder.Property(p => p.SoundboardId)
            .HasColumnType("int")
			.IsRequired();

		builder.Property(p => p.NeckId)
	        .HasColumnType("int")
	        .IsRequired();

		builder.Property(p => p.FretboardId)
	        .HasColumnType("int")
	        .IsRequired();

		builder.Property(p => p.TremoloTypeId)
	        .HasColumnType("int");

		builder.Property(p => p.PickupSetId)
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
