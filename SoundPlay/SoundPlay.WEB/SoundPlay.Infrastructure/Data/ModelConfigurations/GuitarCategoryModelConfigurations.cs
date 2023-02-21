namespace SoundPlay.DAL.Data.ModelConfigurations;

internal sealed class GuitarCategoryConfiguration : IEntityTypeConfiguration<GuitarCategory>
{
    public void Configure(EntityTypeBuilder<GuitarCategory> builder)
    {
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
