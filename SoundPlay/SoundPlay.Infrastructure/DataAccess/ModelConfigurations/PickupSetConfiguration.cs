namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class PickupSetConfiguration : IEntityTypeConfiguration<PickupSet>
{
    public void Configure(EntityTypeBuilder<PickupSet> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}