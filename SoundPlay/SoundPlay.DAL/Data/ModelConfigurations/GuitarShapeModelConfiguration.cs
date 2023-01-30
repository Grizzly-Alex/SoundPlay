namespace SoundPlay.DAL.Data.ModelConfigurations;

internal sealed class GuitarShapeModelConfiguration : IEntityTypeConfiguration<GuitarShape>
{
    public void Configure(EntityTypeBuilder<GuitarShape> builder)
    {
        builder.ToTable("GuitarShapes")
            .HasKey(p => p.Id)
            .HasName("ShapeId");

        builder.Property(p => p.Id)
            .HasColumnName("Id");

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
