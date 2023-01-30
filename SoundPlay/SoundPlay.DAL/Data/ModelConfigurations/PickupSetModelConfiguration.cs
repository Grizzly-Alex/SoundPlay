namespace SoundPlay.DAL.Data.ModelConfigurations;

internal sealed class PickupSetModelConfiguration : IEntityTypeConfiguration<PickupSet>
{
    public void Configure(EntityTypeBuilder<PickupSet> builder)
    {
        builder.ToTable("PickupSets")
            .HasKey(p => p.Id)
            .HasName("PickupSetId");

        builder.Property(p => p.Id)
            .HasColumnName("Id");

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}