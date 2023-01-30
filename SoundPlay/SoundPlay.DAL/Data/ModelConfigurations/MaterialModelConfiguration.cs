namespace SoundPlay.DAL.Data.ModelConfigurations;

internal sealed class MaterialModelConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable("Materials")
            .HasKey(p => p.Id)
            .HasName("MaterialId");

        builder.Property(p => p.Id)
            .HasColumnName("Id");

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
