namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class ColorConfiguration : IEntityTypeConfiguration<Color>
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
