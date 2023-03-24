namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class TremoloTypeConfiguration : IEntityTypeConfiguration<TremoloType>
{
    public void Configure(EntityTypeBuilder<TremoloType> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
