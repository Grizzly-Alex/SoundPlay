namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class GuitarShapeModelConfiguration : IEntityTypeConfiguration<GuitarShape>
{
    public void Configure(EntityTypeBuilder<GuitarShape> builder)
    {
        builder.Property(p => p.Id)
            .HasColumnName("id");

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
