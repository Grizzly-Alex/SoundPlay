namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class GuitarShapeConfiguration : IEntityTypeConfiguration<GuitarShape>
{
    public void Configure(EntityTypeBuilder<GuitarShape> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
