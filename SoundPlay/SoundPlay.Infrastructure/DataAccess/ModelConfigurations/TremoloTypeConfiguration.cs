namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class TremoloTypeConfiguration : IEntityTypeConfiguration<TremoloType>
{
    public void Configure(EntityTypeBuilder<TremoloType> builder)
    {
        builder.Property(p => p.Id)
            .HasColumnName("id");

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
