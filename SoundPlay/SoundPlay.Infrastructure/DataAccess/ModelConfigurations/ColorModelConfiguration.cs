namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class ColorModelConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.Property(p => p.Id)
            .HasColumnName("id")
            .IsRequired();

		builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
