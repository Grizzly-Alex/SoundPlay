namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
