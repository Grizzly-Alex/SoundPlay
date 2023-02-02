namespace SoundPlay.DAL.Data.ModelConfigurations;

internal sealed class PickupSetModelConfiguration : IEntityTypeConfiguration<PickupSet>
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