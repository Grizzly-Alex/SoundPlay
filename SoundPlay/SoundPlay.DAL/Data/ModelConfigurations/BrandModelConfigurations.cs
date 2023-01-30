namespace SoundPlay.DAL.Data.ModelConfigurations;

internal sealed class BrandModelConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands")
            .HasKey(p => p.Id)
            .HasName("BrandId");

        builder.Property(p => p.Id)
            .HasColumnName("Id");

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
