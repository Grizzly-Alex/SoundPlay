namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class GuitarCategoryConfiguration : IEntityTypeConfiguration<GuitarCategory>
{
    public void Configure(EntityTypeBuilder<GuitarCategory> builder)
    {
        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.Name)
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
