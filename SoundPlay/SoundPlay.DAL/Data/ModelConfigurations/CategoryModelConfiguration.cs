namespace SoundPlay.DAL.Data.ModelConfigurations;

internal sealed class CategoryModelConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories")
            .HasKey(p => p.Id)
            .HasName("CategoryId");

        builder.Property(p => p.Id)
            .HasColumnName("Id");

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
