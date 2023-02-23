namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class PickupSetConfiguration : IEntityTypeConfiguration<PickupSet>
{
    public void Configure(EntityTypeBuilder<PickupSet> builder)
    {
        builder.Property(p => p.Id)
            .HasColumnName("id");

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}