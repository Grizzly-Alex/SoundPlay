namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
{
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
        builder.Property(bi => bi.UnitPrice)
            .HasColumnType("decimal")
            .HasPrecision(8, 2)
            .IsRequired();
    }
}
